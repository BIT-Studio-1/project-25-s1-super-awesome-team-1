using System.ComponentModel.Design;
using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using System.Text;
using System.Threading;
using System.Xml.Linq;
using Microsoft.VisualBasic;
using static System.Formats.Asn1.AsnWriter;

namespace Studio1Project
{
    public struct Weapon
    {
        public string name;
        public int minDamage;
        public int maxDamage;
        public int block;
        public int staminaCost;
    }
    internal class Program
    {
        private static int roomChoice=1, health = 100, stamina = 100, prev = 1, sleepCounter = 0, lossCount=0;
        private static string action = "";
        private static List<string> inv = new List<string>();
        private static Weapon playerWeapon;
        private static string[] infirmaryItems = { "health potion", "energy stim", "lab note" },labItems= { "energy stim", "health potion" }, roomsVisited = { "?", "???????", "??????", "???????", "???????????????", "???????", "???", "??????", "?????????", "?????????????", "?????????", "??????????", "??????????" };

        const int SW_MAXIMIZE = 3;
        [DllImport("kernel32.dll", ExactSpelling = true)]
        static extern IntPtr GetConsoleWindow();
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);
        static void Main(string[] args)
        {
            IntPtr consoleWindow = GetConsoleWindow();
            if (consoleWindow != IntPtr.Zero)
            {
                ShowWindow(consoleWindow, SW_MAXIMIZE);
            }
            weaponEquip("fists", 5, 15, 5, 10);//name, mindmg, maxdmg, block, staminacost
            do
            {
                if(lossCount == 10)
                {
                    roomChoice = 9998;
                }
                Console.Clear();
                switch (roomChoice)
                {

                    case 1:
                        roomsVisited[0] = "Cell";
                        PrisonCell();
                        break;
                    case 2:
                        roomsVisited[1] = "Hallway";
                        DungeonHall();
                        break;
                    case 3:
                        roomsVisited[2] = "Sewers";
                        Sewers();
                        break;
                    case 4:
                        roomsVisited[3] = "Kitchen";
                        Kitchen();
                        break;
                    case 5:
                        roomsVisited[4] = "Guards Barracks";
                        GuardsBarracks();
                        break;
                    case 6:
                        roomsVisited[5] = "Showers";
                        Showers();
                        break;
                    case 7:
                        roomsVisited[6] = "Lab";
                        Lab();
                        break;
                    case 8:
                        roomsVisited[7] = "Pantry";
                        Pantry();
                        break;
                    case 9:
                        roomsVisited[8] = "Infirmary";
                        Infirmary();
                        break;
                    case 10:
                        roomsVisited[9] = "Training Yard";
                        TrainingYard();
                        break;
                    case 11:
                        roomsVisited[10] = "Courtyard";
                        Courtyard();
                        break;
                    case 12:
                        roomsVisited[11] = "Gate House";
                        GateHouse();
                        break;
                    case 13:
                        roomsVisited[12] = "Tower Base";
                        TowerBase();
                        break;
                    case 9999:                       
                        Console.WriteLine("You win! Do you want to play again? y/n");
                        action = Console.ReadLine();
                        if (action == "y")
                        {
                            reset();
                            break;
                        } else
                        {
                            Console.WriteLine("bye");
                            Thread.Sleep(2000);
                            return;
                        }
                    case 9998:
                        Console.WriteLine("You lose! Do you want to play again? y/n");
                        action = Console.ReadLine();
                        if (action == "y")
                        {
                            reset();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("bye");
                            Thread.Sleep(2000);
                            return;
                        }
                }

            }while (roomChoice != 0);

            Thread.Sleep(1000);
        }
        //All of the rooms 
        static void PrisonCell()//room 1 (main room)
        {

            Console.WriteLine("You awaken in a dimly lit cell, the cold stone walls echoing with the faint sounds of distant footsteps.\nThe air is thick with the scent of dampness and despair. A single flickering light bulb casts long shadows.");
            Console.WriteLine("You have no memory of how you got here, but you know one thing: you must escape.The clock is ticking, and the guards are unpredictable.\nEach room you navigate brings you closer to freedom—or deeper into the labyrinth of the prison's mysteries.\nWith your mission in mind you start exploring your surroundings...\n");
            bool validInput = false;
            Random random = new Random();
            while (!validInput)
            {
                //guard prompt will only be displayed, if the keys haven't been picked up yet
                if (!inv.Contains("cell keys"))
                {
                    Console.WriteLine("A guard snores loudly just outside, slouched in a wooden chair, keys hanging loosely from his belt.");
                }

                Console.WriteLine("As you scan the cell, you notice a loose stone at the back wall. Behind it, there's a faint draft—it must lead to the sewers.\n");
                Console.WriteLine();
                Console.Write(">> ");
                action = Console.ReadLine().ToLower();
                Console.Clear();
                switch (action)
                {
                    case "hall":
                    case "halll":
                    case "hallway":
                    case "dungeon hall":
                    case "open cell":
                        if (inv.Contains("cell keys"))
                        {
                            roomChoice = 2;
                            validInput = true;
                        }
                        else
                        {
                            Console.WriteLine("Your cell is locked Do you want to take the keys from the guard. Yes or No");
                            action = Console.ReadLine().ToLower().Remove(1);
                            if(action== "y")
                            {
                                Console.WriteLine("You Reach for the guards keys ");
                                int success =random.Next(10);
                                if (success < 4 )
                                {
                                    Console.WriteLine("you successfully take the keys from the guard");
                                    inv.Add("cell keys");
                                    roomChoice = 2;
                                    validInput = true;
                                }
                                else
                                {
                                    Console.WriteLine("the Guard spots you prepare for a fight");
                                    string outCome = combat(20, 3, 1, 5);//health,def,mindmg,maxdmg

                                    if (outCome == "win") {
                                        inv.Add("cell keys");
                                        roomChoice = 2;
                                        validInput = true;
                                    }
                                    else {
                                        Console.WriteLine("lose");
                                        if (health <=0 || stamina <= 0)
                                        {
                                            Console.WriteLine("");
                                            health = 50;
                                            stamina = 50;
                                            lossCount++;
                                        }
                                        else {
                                            Console.WriteLine("");
                                        }
                                    }//idk what to do if you lose
                                };
                            }
                            else { 
                                roomChoice = 1;
                            }
                        }
                        break;
                    case "sewers":
                    case "go to sewers":
                    case "sewer":
                        roomChoice = 3;
                        validInput = true;
                        break;
                    case "back":
                    case "return":
                    case "go back":
                        roomChoice = prev;
                        GoBack();
                        validInput = true;
                        break;
                    case "test":
                        roomChoice = Convert.ToInt32(Console.ReadLine());
                        validInput = true;
                        break;
                    case "help":
                    case "h":
                        showCommands();
                        break;
                    case "map":
                        showMap();
                        break;
                    case "sleep":
                        Console.WriteLine("You lie back on the cold stone floor and close your eyes. Despite the discomfort, you manage to rest.");
                        
                        Console.WriteLine("Sleeping helped you regain some energy!!");
                        sleepCounter = sleepCounter + 1;
                        stamina = stamina + 10;
                        if (sleepCounter > 10)
                        {
                            roomChoice = 9999;
                            validInput = true;
                        }
                        break;
                    case "show energy":
                        showEnergyLevels();
                        break;
                    case "show inventory":
                    case "inv":
                        inventoryShow();
                        break;
                    default:
                        Console.WriteLine("Try something else!");
                        break;
                }
            }
        }
        static void DungeonHall()//Room 2
        {
            Console.WriteLine();           
            Console.WriteLine("You quietly step into the dimly lit dungeon hall.");
            bool validInput = false;
            while (!validInput)
            {
                Console.WriteLine();
                Console.WriteLine("Shadows stretch along the damp stone corridor, torches flickering weakly in rusted sconces.");
                Console.WriteLine("To your left, heavy boots echo faintly from the guard barracks. Ahead, the scent of stale broth and overcooked meat wafts from the kitchen.");
                Console.WriteLine("Behind you, your cell waits — but that’s not a place you want to return to.");
                Console.WriteLine();
                Console.Write(">> ");
                action = Console.ReadLine().ToLower();
                Console.Clear();
                switch (action)
                {
                    case "cell":
                        prev = roomChoice;
                        roomChoice = 1;
                        validInput = true;
                        break;
                    case "guard barracks":
                    case "gaurd barracks":
                    case "left":
                        prev = roomChoice;
                        roomChoice = 5;
                        validInput = true;
                        break;
                    case "kitchen":
                    case "forward":
                        prev = roomChoice;
                        roomChoice = 4;
                        validInput = true;
                        break;
                    case "back":
                    case "return":
                    case "go back":
                        roomChoice = prev;
                        GoBack();
                        validInput = true;
                        break;
                    case "help":
                        showCommands();
                        break;
                    case "map":
                        showMap();
                        break;
                    case "show energy":
                        showEnergyLevels();
                        break;
                    case "show inventory":
                    case "inv":
                        inventoryShow();
                        break;
                    default:
                        Console.WriteLine("Try something else!");
                        break;
                }
            }
        }
        static void Sewers()//room 3
        {
            Console.WriteLine("You drop down into the sewers, landing with a wet splash. The tunnel stinks of rot and mold.");


            bool validInput = false;
            while (!validInput)
            {
                Console.WriteLine("To your left, the tunnel narrows into a tiled area where water drips steadily — it sounds like an old washroom.");
                Console.WriteLine("To your right, faint lights flicker behind a rusted iron grate, and a sharp chemical odor hangs in the air.");
                Console.WriteLine("Behind you is the tunnel you crawled through to get here.");
                Console.WriteLine();
                Console.Write(">> ");

                action = Console.ReadLine().ToLower();
                Console.Clear();
                switch (action)
                {
                    case "cell":
                    case "celll":
                    case "tunnel":
                        prev = roomChoice;
                        roomChoice = 1;
                        validInput = true;
                        break;
                    case "showers":
                    case "showerss":
                    case "go to showers":
                    case "left":
                    case "go left":
                    case "washroom":
                    case "wash room":
                    case "go to washroom":
                        prev = roomChoice;
                        roomChoice = 6;
                        validInput = true;
                        break;
                    case "lab room":
                    case "labroom":
                    case "lab":
                    case "go to lab":
                    case "right":
                    case "go right":
                        prev = roomChoice;
                        roomChoice = 7;
                        validInput = true;
                        break;
                    case "back":
                    case "return":
                    case "go back":
                        roomChoice = prev;
                        GoBack();
                        validInput = true;
                        break;
                    case "help":
                        showCommands();
                        break;
                    case "map":
                        showMap();
                        break;
                    case "show energy":
                        showEnergyLevels();
                        break;
                    case "show inventory":
                    case "inv":
                        inventoryShow();
                        break;
                    default:
                        Console.WriteLine("Try something else!");
                        break;
                }
            }
        }
        static void Kitchen()//Room4
        {
            Console.WriteLine("You step into the prison kitchen. Grease stains mark the floor, and a single pot boils unattended, filling the air with a sour, meaty smell.");


            bool validInput = false;
            while (!validInput)
            {
                Console.WriteLine("To your left, a narrow door leads to what looks like a pantry — you hear muffled movement inside.");
                Console.WriteLine("Behind you is the corridor leading back to the dungeon hall.");
                Console.WriteLine();
                Console.Write(">> ");
                action = Console.ReadLine().ToLower();
                Console.Clear();
                switch (action)
                {
                    case "dungeon hall":
                    case "hall":
                    case "hallway":
                    case "behind":
                    case "corridor":
                        prev = roomChoice;
                        roomChoice = 2;
                        validInput = true;
                        break;
                    case "pantry storage":
                    case "left":
                        prev = roomChoice;
                        roomChoice = 8;
                        validInput = true;
                        break;
                    case "back":
                    case "return":
                    case "go back":
                        roomChoice = prev;
                        GoBack();
                        validInput = true;
                        break;
                    case "help":
                        showCommands();
                        break;
                    case "eat":
                        Console.WriteLine("You approach the bubbling pot and take a taste of the food inside. It helps you regain some energy!\n\n");
                        stamina = stamina + 5;
                        break;
                    case "map":
                        showMap();
                        break;
                    case "show energy":
                        showEnergyLevels();
                        break;
                    case "show inventory":
                    case "inv":
                        inventoryShow();
                        break;
                    default:
                        Console.WriteLine("Try something else!");
                        break;
                }
            }
        }
        static void GuardsBarracks()//Room5 SSSSSSS
        {
            Console.Clear();
            Console.WriteLine("You push the heavy wooden door open. It groans on rusted hinges, but the corridor beyond remains silent.");
            Console.WriteLine("The barracks are dim. Torches flicker low, casting restless shadows that dance across rows of unmade bunks and battered lockers.");
            Console.WriteLine("The smell hits you first — sweat, oil, and something long past edible. A half-eaten loaf lies beside a dented helmet.");
            Console.WriteLine("You see no guards... but the clutter tells you they were here not long ago.");
            Console.WriteLine();
            Thread.Sleep(2000);

            bool validInput = false;
            while (!validInput)
            {
                Console.WriteLine("There are three doors: one marked with the red cross of the Infirmary, the other one leading out to the Training Yard. The last one seems to lead in to a hallway.");
                Console.WriteLine("You could also take a moment to look around the barracks.");
                Console.WriteLine();
                Console.Write(">> ");

                action = Console.ReadLine().ToLower();
                Console.Clear();
                switch (action)
                {
                    case "infirmary":
                    case "go to infirmary":
                    case "goto infirmary":
                    case "infirm":
                        prev = roomChoice;
                        roomChoice = 9;
                        validInput = true;
                        break;
                    case "training yard":
                    case "go to training yard":
                    case "goto training yard":
                    case "t/y":
                        prev = roomChoice;
                        roomChoice = 10;
                        validInput = true;
                        break;
                    case "dungeon hall":
                    case "hall":
                    case "hallway":
                    case "corridor":
                        prev = roomChoice;
                        roomChoice = 2;
                        validInput = true;
                        break;
                    case "back":
                    case "return":
                    case "go back":
                        roomChoice = prev;
                        GoBack();
                        validInput = true;
                        break;
                    case "search room":
                    case "search":
                        Console.WriteLine();
                        Console.WriteLine("You sift through the mess. Most of it is junk—empty bottles, broken gear...");
                        Console.WriteLine("But tucked under a thin mattress, you find a dusty but intact Guard’s Sword.");
                        Console.WriteLine("Would you like to pickup the Guard's Sword?.");
                        Console.WriteLine();
                        Console.Write(">> ");
                        string userInput = Console.ReadLine().ToLower();
                        Console.WriteLine();
                        if (userInput[0] == 'y')
                        {
                            Console.WriteLine("Your fingers tremble as they curl around the hilt of the Guard's Sword.");
                            Console.WriteLine("The cold steel sends a shiver up your spine, its unexpected weight pressing into your palms like an unspoken challenge.");
                            Console.WriteLine("You lift it slowly, the blade catching the dim light, whispering promises of both protection and peril.");
                            Thread.Sleep(3000);
                            weaponEquip("sword", 10, 20, 10, 15);
                        }
                        else
                        {
                            Console.WriteLine("You leave the dusty sword, trusting in your fists");
                            weaponEquip("fists", 5, 15, 5, 10);
                            Thread.Sleep(1500);
                        }
                        Console.WriteLine();
                        break;
                    case "show inventory":
                    case "inv":
                        inventoryShow();
                        break;
                    case "map":
                        showMap();
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("You stand still, listening. Was that a creak? Or just the wind?");
                        Thread.Sleep(1000);
                        Console.WriteLine();
                        break;
                }
            }
        }
        static void Showers()//Room6 SSSSSSSSSSSSSSSSS
        {
            Console.WriteLine("You grip the rusted ladder rungs and climb up, feet slipping slightly on the damp metal.");
            Console.WriteLine("A cold draft hits you as you emerge into a crumbling shower room. Water drips steadily from cracked pipes above, echoing through the tiled space.");
            Console.WriteLine("The walls are stained with age and mold, and the sour smell of mildew clings to the air.");
            Console.WriteLine("Light from a window overhead casts strange shadows between the rows of broken stalls.");
            Console.WriteLine("Somewhere in the distance, you hear a metallic clang... then silence.");
            Console.WriteLine();
            Thread.Sleep(2000);

            bool validInput = false;
            while (!validInput)
            {
                Console.WriteLine("There’s a narrow iron door half-hinged open, marked faintly with the red cross of the Infirmary.");
                Console.WriteLine("You could also climb back down into the sewers, if you’d rather not linger here any longer.");
                Console.WriteLine();
                Console.Write(">> ");

                action = Console.ReadLine().ToLower();
                Console.Clear();
                switch (action)
                {
                    case "infirmary":
                    case "infirm":
                    case "go to infirmary":
                    case "goto infirmary":
                        prev = roomChoice;
                        roomChoice = 9;
                        validInput = true;
                        break;
                    case "back":
                    case "return":
                    case "go back":
                        roomChoice = prev;
                        GoBack();
                        validInput = true;
                        break;
                    case "search room":
                    case "search":
                        Console.WriteLine();
                        Console.WriteLine("You move cautiously between the cracked stalls and broken tiles, checking behind pipes and under benches.");
                        Console.WriteLine("Slippery moss clings to your boots. The floor creaks in protest, and for a moment, you think you spot movement—but it's just a shadow.");
                        Console.WriteLine($"After a few minutes of careful searching, you find...");
                        Thread.Sleep(2000);
                        Console.WriteLine("Nothing of use.");
                        Console.WriteLine("Just rusted plumbing, mold, and the faint feeling that someone *was* here long before you.");
                        Thread.Sleep(2000);
                        Console.WriteLine();
                        break;
                    case "show inventory":
                    case "inv":
                        inventoryShow();
                        break;
                    case "map":
                        showMap();
                        break;
                    default:
                        GoBack();
                        Console.WriteLine();
                        break;
                }
            }
        }
        static void Lab()//Room7 SSSSSSSSSSSSSSSSSSS
        {
            Console.Clear();
            Console.WriteLine("You step into the laboratory through a heavy steel door that groans against its hinges.");
            Console.WriteLine("Dust dances in the stale air, lit by flickering overhead lights. Rows of broken vials, shattered beakers, and rusted equipment clutter the counters.");
            Console.WriteLine("A thick chemical smell still lingers—acrid and sharp. This place hasn’t been used in a long time… or maybe it has, just not for science.");
            Console.WriteLine();
            Thread.Sleep(2000);

            bool validInput = false;
            while (!validInput)
            {
                Console.WriteLine("There’s a door leading to the Training Yard, its reinforced window cracked but intact.");
                Console.WriteLine("You could also Go Back the way you came, retracing your steps through the dungeon.");
                Console.WriteLine();
                Console.Write(">> ");

                action = Console.ReadLine().ToLower();
                Console.Clear();
                switch (action)
                {
                    case "training yard":
                    case "go to training yard":
                    case "goto training yard":
                    case "t/y":
                        prev = roomChoice;
                        roomChoice = 10;
                        validInput = true;
                        break;
                    case "back":
                    case "return":
                    case "go back":
                        roomChoice = prev;
                        GoBack();
                        validInput = true;
                        break;
                    case "search room":
                    case "search":
                        Console.WriteLine("You sift through the dusty tables and shattered glass. Most things are ruined or unusable...");
                        Console.WriteLine("After a thorough search, find a *Health Potion* and a slightly dusty *Energy Stim* That you could pickup .");
                        break;
                    case "pickup":
                        pickup(ref labItems);
                        break;
                    case "show inventory":
                    case "inv":
                        inventoryShow();
                        break;
                    case "map":
                        showMap();
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("The hum of broken equipment fills the silence. You hesitate, second-guessing your next move.");
                        Console.WriteLine();
                        break;
                }
            }
        }
        static void Pantry()//Room8 Albert
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("You step into the pantry. The air is thick with the scent of dried herbs, aged meat, and flour.");
            Console.WriteLine("Wooden shelves sag under the weight of preserved goods, though many have been picked over.");
            Console.WriteLine("Scraps of labels and cracked jars suggest someone or something has raided this place recently.");
            Console.WriteLine();
            Thread.Sleep(2000);

            bool validInput = false;
            while (!validInput)
            {
                Console.WriteLine("To your left, a narrow archway leads back to the Kitchen — faint light flickers from a distant torch.");
                Console.WriteLine("Beyond a storage rack, a battered door swings gently open, revealing a path toward the Courtyard.");
                Console.WriteLine("You can also step back the way you came.");
                Console.WriteLine();
                Console.Write(">> ");

                action = Console.ReadLine().ToLower();
                Console.Clear();
                switch (action)
                {
                    case "kitchen":
                        prev = roomChoice;
                        roomChoice = 4;
                        validInput = true;
                        break;
                    case "courtyard":
                    case "c/y":
                        prev = roomChoice;
                        roomChoice = 11;
                        validInput = true;
                        break;
                    case "back":
                    case "return":
                    case "go back":
                        roomChoice = prev;
                        GoBack();
                        validInput = true;
                        break;
                    case "search room":
                    case "search":
                        Console.WriteLine("You scan the shelves, digging through empty jars and broken crates...");
                        Thread.Sleep(1000);
                        Console.WriteLine("Nothing useful — just crumbs and cobwebs. Someone’s already cleaned this place out.");
                        break;
                    case "show inventory":
                    case "inv":
                        inventoryShow();
                        break;
                    case "map":
                        showMap();
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("The pantry creaks softly around you. Nothing happens.");
                        Console.WriteLine();
                        Thread.Sleep(1000);
                        break;
                }
            }
        }
        static void Infirmary()//Room9 Albert
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("You step quietly into the infirmary. The walls are lined with rusted medical cabinets, some hanging open, their contents long looted.");
            Console.WriteLine("The scent of alcohol and old blood hangs in the air, mixing with something faintly sweet — herbs, perhaps.");
            Console.WriteLine("A torn cot leans against the wall, and broken vials crunch underfoot as you move.");
            Console.WriteLine();
            Thread.Sleep(2000);

            bool validInput = false;

            while (!validInput)
            {
                Console.WriteLine("There’s a narrow iron door half-hinged open, leading back into the sweat-soaked air of the **Guards’ Barracks**.");
                Console.WriteLine("Beyond the flickering lantern light, a tiled corridor veers off toward the Showers, echoing with the faint sound of dripping water.");
                Console.WriteLine("A heavier, creaking wooden door opens to the Courtyard, where cool air stirs through the cracks.");
                Console.WriteLine("Or... you could always double back the way you came, if none of this feels right.");
                Console.WriteLine();
                Console.Write(">> ");

                action = Console.ReadLine().ToLower();
                Console.Clear();
                switch (action)
                {
                    case "guard barracks":
                    case "guards barracks":
                    case "go to guard barracks":
                        prev = roomChoice;
                        roomChoice = 5;
                        validInput = true;
                        break;
                    case "showers":
                        prev = roomChoice;
                        roomChoice = 6;
                        validInput = true;
                        break;
                    case "courtyard":
                        prev = roomChoice;
                        roomChoice = 11;
                        validInput = true;
                        break;
                    case "back":
                    case "return":
                    case "go back":
                        roomChoice = prev;
                        GoBack();
                        validInput = true;
                        break;
                    case "search":
                    case "inspect":
                    case "look around":
                        Console.WriteLine();
                        Console.WriteLine("You rummage through a mostly intact cabinet beneath a cracked sink.");
                        Console.WriteLine("To your surprise, you find a small vial labeled *Health Potion* and a slightly dusty *Energy Stim* That you could pickup");
                        Console.WriteLine("inside the pocket of the lab coat you find a note");
                        Thread.Sleep(2000);
                        break;
                    case "show inventory":
                    case "inv":
                        inventoryShow();
                        break;
                    case "map":
                        showMap();
                        break;
                    case "pickup":
                        pickup(ref infirmaryItems);
                        break;
                    default:
                        Console.WriteLine("The flickering lantern casts eerie shadows across the walls.");
                        Thread.Sleep(1000);
                        break;
                }
            }
        }
        static void TrainingYard()//Room10 Albert
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("You step into the open Training Yard. Dirt and dust swirl in the wind as the clang of metal echoes faintly from beyond.");
            Console.WriteLine("Faded dummies line the edges, and broken weapon shafts are scattered across the ground.");
            Console.WriteLine();
            Console.WriteLine("Your eyes scan the yard, settling on a guard leisurely sipping from his flask.");
            Console.WriteLine("As the last drop vanishes, he exhales, then turns—his gaze meeting yours with piercing intensity.");
            Console.WriteLine("The air thickens as he straightens, hand instinctively hovering near his weapon, prepared for whatever comes next.");
            Console.WriteLine();

            if (inv.Contains("Gatehouse Key"))
            {               
                Console.WriteLine("You see the guard you fought earlier, motionless and slumped on the ground.");
                Console.WriteLine("He appears to be dreaming about the fight—but luckily, he’s still unconscious.");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Your eyes scan the yard, settling on a guard leisurely sipping from his flask.");
                Console.WriteLine("As the last drop vanishes, he exhales, then turns—his gaze meeting yours with piercing intensity.");
                Console.WriteLine("The air thickens as he straightens, hand instinctively hovering near his weapon, prepared for whatever comes next.");
                Console.WriteLine();
                Thread.Sleep(3000);

                string outCome = combat(75, 6, 11, 15);

                if (outCome == "win")
                {
                    Console.Clear();
                    Console.WriteLine("The guard collapses at your feet, unmoving.");
                    Console.WriteLine("You crouch beside him and search his pockets carefully.");
                    Console.WriteLine("Your fingers brush against something cold and metallic—keys.");
                    Console.WriteLine("You grab them without hesitation, a surge of hope rising in your chest.");
                    Console.WriteLine("Standing up, you take a slow, deliberate look around the yard.");
                    Console.WriteLine("The air is still, but you can’t shake the feeling that you’re being watched.");
                    Console.WriteLine("Time to move... but where to first?"); 
                    inv.Add("Gatehouse Key");
                    Thread.Sleep(3000);
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Pain surges through your body as you collapse to the ground, defeated.");
                    Console.WriteLine("The guard stands over you, victorious, his expression unreadable.");
                    Console.WriteLine("He methodically searches you, stripping away your hard-earned items one by one.");
                    Console.WriteLine("You try to resist, but your limbs are heavy and uncooperative.");
                    Console.WriteLine("With a grunt, he hauls you up and begins dragging you back toward the cell.");
                    Console.WriteLine("The cold stone floor scrapes against you as the shadows of freedom fade behind.");
                    Console.WriteLine("The door slams shut with a metallic clang... You're back where you started.");
                    Console.WriteLine();
                    inv.Clear();
                    weaponEquip("fists", 5, 15, 5, 10);
                    lossCount++;
                    Thread.Sleep(5000);
                    prev = 1;
                    roomChoice = 1;
                    return;
                }
            }

            bool validInput = false;

            while (!validInput)
            {
                Console.WriteLine();
                Console.WriteLine("There’s a gate at the far end, leading back into the Guards’ Barracks, where voices echo faintly through stone walls.");
                Console.WriteLine("Off to the side, a rusted service hatch opens into the dimly-lit Lab, the air thick with chemicals.");
                Console.WriteLine("To the east, a heavy wooden door leads to the open Courtyard, where the scent of grass cuts through the dust.");
                Console.WriteLine("And of course, you could always retrace your steps and leave the yard the way you came.");
                Console.WriteLine();
                Console.Write(">> ");

                action = Console.ReadLine().ToLower();
                Console.Clear();
                switch (action)
                {
                    case "lab room":
                    case "labroom":
                        prev = roomChoice;
                        roomChoice = 7;
                        validInput = true;
                        break;
                    case "guard barracks":
                    case "guards barracks":
                    case "go to guard barracks":
                    case "barracks":
                    case "barrack":
                        prev = roomChoice;
                        roomChoice = 5;
                        validInput = true;
                        break;
                    case "courtyard":
                    case "c/y":
                    case "go to courtyard":
                    case "goto courtyard":
                    case "yard":
                        prev = roomChoice;
                        roomChoice = 11;
                        validInput = true;
                        break;
                    case "back":
                    case "return":
                    case "go back":
                        roomChoice = prev;
                        GoBack();
                        validInput = true;
                        break;
                    case "search room":
                    case "search":
                    case "inspect":
                    case "look around":
                        Console.WriteLine();
                        Console.WriteLine("You take a moment to search the yard, scanning the ground and checking under broken training dummies.");
                        Console.WriteLine("Most of what you find is useless — splintered wood, dulled blades, and worn-out gear.");
                        Thread.Sleep(1000);
                        break;
                    case "show inventory":
                    case "inv":
                        inventoryShow();
                        break;
                    case "map":
                        showMap();
                        break;
                    default:
                        Console.WriteLine();
                        Console.WriteLine("The yard is quiet, save for the breeze. You'll need to pick a direction or do something useful.");
                        Thread.Sleep(1000);
                        break;
                }
            }
            }
        static void Courtyard()//Room11
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("You step out into the Courtyard. The open sky stretches above — a rare sight down here. Moss clings to crumbling stone walls, and the faint sound of birdsong feels almost surreal.");
                Console.WriteLine("A broken statue of a knight stands guard in the center, its face worn smooth by time. The air smells of damp earth and old battle.");
                Console.WriteLine();
                Thread.Sleep(2000);

                bool validInput = false;

                while (!validInput)
                {

                    Console.WriteLine("There’s a barely visible grate behind a thorny bush — the passage to the Pantry.");
                    Console.WriteLine("A heavy oak door marked with a faded red cross leads into the Infirmary.");
                    Console.WriteLine("The Training Yard lies just beyond a sagging wooden gate, its hinges creaking in the breeze.");
                    Console.WriteLine("A winding stone path leads up to the Ancient Tower, its silhouette sharp against the sky.");
                    Console.WriteLine("Another narrow path disappears toward the looming Gatehouse, where freedom might yet be possible.");
                    Console.WriteLine();
                    Console.Write(">> ");

                    action = Console.ReadLine().ToLower();
                    Console.Clear();
                    switch (action)
                    {
                        case "gatehouse":
                        case "exit":
                        case "gate":
                            roomChoice = 12;
                            validInput = true;
                            break;
                        case "tower base":
                        case "tower":
                        case "watch tower":
                            roomChoice = 13;
                            validInput = true;
                            break;
                        case "pantry storage":
                        case "pantry":
                            roomChoice = 8;
                            validInput = true;
                            break;
                        case "infirmary":
                        case "infirm":
                            roomChoice = 9;
                            validInput = true;
                            break;
                        case "training yard":
                        case "t/y":
                            roomChoice = 10;
                            validInput = true;
                            break;
                        case "back":
                        case "return":
                        case "go back":
                            roomChoice = prev;
                            GoBack();
                            validInput = true;
                            break;
                        case "search":
                        case "search area":
                        case "search room":
                        case "inspect":
                        case "look around":
                        Console.WriteLine("You scour the courtyard, but all that's left are whispers of long-forgotten days.");
                            break;
                        case "show inventory":
                        case "inv":
                            inventoryShow();
                            break;
                        case "map":
                            showMap();
                            break;
                        default:
                            Console.WriteLine();
                            Console.WriteLine("You pause in the courtyard, listening to the wind rattle the gate. There are many paths here — some leading forward, others perhaps to freedom.");
                            Thread.Sleep(1000);
                            Console.WriteLine();
                            break;
                    }
                }
            }
        static void GateHouse()//Room12 EXIT
            {
                Console.Clear();
                Console.WriteLine();
                Console.WriteLine("You step into the Gatehouse — a stone chamber looming with rusted chains and gear levers, once used to raise the portcullis.");
                Console.WriteLine("Dust blankets every surface, and faded banners hang limp on the walls, whispering of long-forgotten glory.");
                Console.WriteLine();
                Thread.Sleep(2000);

                bool validInput = false;

                while (!validInput)
                {

                    Console.WriteLine("Ahead, the Castle’s main gate stands sealed — an imposing iron door with a thick lock, its keyhole rusted but still intact. It won’t budge without the right key.");
                    Console.WriteLine("Behind you, the corridor stretches back toward the Courtyard, the faint breeze from outside already starting to fade.");
                    Console.WriteLine();
                    Console.Write(">> ");

                    action = Console.ReadLine().ToLower();
                    Console.Clear();
                    switch (action)
                    {
                        case "courtyard":
                            roomChoice = 11;
                            break;
                        case "back":
                        case "return":
                        case "go back":
                            roomChoice = prev;
                            GoBack();
                            validInput = true;
                            break;
                        case "exit":
                        case "leave":
                        case "escape":
                            if (inv.Contains("Gatehouse Key"))
                            {
                            Console.WriteLine("Your fingers brush against the gate's cold iron as you spot the keyhole—");
                            Console.WriteLine("and then, your heart skips. You have the key.");
                            Console.WriteLine();
                            Console.WriteLine("With a deep breath, you slide it into place. It fits perfectly.");
                            Console.WriteLine("A heavy *click* echoes through the air as the mechanism unlocks.");
                            Console.WriteLine("The gate creaks open, revealing the path beyond the castle walls—freedom at last.");
                            Console.WriteLine();
                            Console.WriteLine("You step into the fading light, the wind fresh against your skin.");
                            Console.WriteLine("You’ve made it out.");
                            Console.WriteLine();
                            roomChoice = 9999;
                            validInput = true;
                            }
                            else
                            {
                            Console.WriteLine("You study the keyhole, its shape unmistakable. But no key in your possession fits. Defeated, you turn away, the promise of freedom lingering just beyond your grasp.");
                            Console.WriteLine();
                            Thread.Sleep(2000);
                            }
                        break;
                        case "search":
                        case "search room":
                        case "inspect":
                        case "look around":
                        Console.WriteLine("You carefully search the area, eyes scanning every nook and cranny.");
                            Console.WriteLine("Dust swirls in the stale air, but nothing of value reveals itself.");
                            Console.WriteLine("If there’s a key here, it’s long gone.");
                            Console.WriteLine();
                            Thread.Sleep(1000);
                            break;
                        case "show inventory":
                        case "inv":
                            inventoryShow();
                            break;
                        default:
                            Console.WriteLine();
                            Console.WriteLine("The gatehouse groans with age, but stands firm. The wind outside whispers of freedom... or of danger.");
                            Console.WriteLine();
                            Thread.Sleep(1000);
                            break;
                    }
                }
            }
        static void TowerBase()//Room13
            {
                Console.WriteLine();
                Console.WriteLine("You stand at the base of the ancient tower, its worn stones rising like silent sentinels into the misty sky.");
                Console.WriteLine("Looking back you see a narrow, winding path leading back down to the Courtyard, the distant sounds of castle life faint on the breeze.");
                Console.WriteLine("The wooden door behind you creaks softly, offering a way inside.");
                Console.WriteLine();
                Thread.Sleep(1500);

                bool validInput = false;

                while (!validInput)
                {

                    Console.WriteLine("What would you like to do?");
                    Console.WriteLine("Perhaps you could explore the path leading away from the tower, or step inside through the door.");
                    Console.WriteLine("You might also take a moment to inspect the area more closely.");
                    Console.WriteLine();
                    Console.Write(">> ");

                    action = Console.ReadLine().ToLower();
                    Console.Clear();
                    switch (action)
                    {
                    case "courtyard":
                        roomChoice = 11;
                        validInput = true;
                        break;
                    case "back":
                    case "return":
                    case "go back":
                        GoBack();
                        roomChoice = prev;
                        validInput = true;
                        break;
                    case "go up":
                    case "up":
                    case "go into tower":
                    case "climb tower":
                    case "climb":
                        TowerClimb();
                        validInput = true;
                        break;
                    case "search":
                    case "inspect":
                    case "look around":
                        Console.WriteLine();
                        Console.WriteLine("You take a slow walk around the base of the tower, scanning the moss-covered stones and worn path.");
                        Console.WriteLine("A few scattered pebbles, dried leaves, and an old bird’s nest are all that greet you.");
                        Console.WriteLine("If anything useful was ever left here, it's long gone.");
                        Console.WriteLine();
                        break;
                    default:
                        Console.WriteLine("You hesitate, uncertain what to do.");
                        Console.WriteLine();
                        Thread.Sleep(1000);
                        break;
                    }
                }
            }
        static void TowerClimb()
            {
                int towerFloor = 1;
                bool jump = false;

                while (towerFloor > 0 && !jump)
                {
                    string option = "";

                    while (towerFloor < 6 && towerFloor > 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"You stand on floor {towerFloor} of the tower. The stone stairs spiral tightly in both directions.");
                        Console.WriteLine("Do you want to climb further or head back down?");
                        Console.WriteLine();
                        Console.Write(">> ");

                        option = Console.ReadLine().ToLower();
                        Console.Clear();
                        switch (option)
                        {
                            case "climb":
                            case "up":
                            case "climb up":
                            case "climb tower":
                                towerFloor++;
                                stamina -= 5;
                            if (stamina <= 0)
                            {
                                Console.WriteLine("You fainted from exhaustion and are sent back to your cell");
                                Thread.Sleep(1000);
                                roomChoice = 1;
                                return;
                            }
                            Console.WriteLine();
                            Console.WriteLine($"You ascend to floor {towerFloor}, your legs growing heavier with each step.");
                                Console.WriteLine($"Stamina: {stamina}");
                                break;
                            case "down":
                            case "go down":
                            case "go back":
                            case "return":
                            case "back":
                                if (towerFloor > 1)
                                {
                                    towerFloor--;
                                Console.WriteLine();
                                Console.WriteLine($"You descend cautiously to floor {towerFloor}, the stairwell dark and narrow.");
                                }
                                else
                                {
                                    Console.WriteLine("You’re already at the base of the tower—you can’t go any lower.");
                                }
                                break;
                            default:
                                Console.WriteLine("The silence in the tower grows heavier as you hesitate.");
                                break;
                        }
                    }

                    if (towerFloor == 6)
                    {
                        Console.WriteLine();
                        Console.WriteLine("At last, you reach the top of the tower. The cold wind bites at your skin as you step onto the open rooftop.");
                        Console.WriteLine("Below, far beyond the castle wall, a river glimmers in the fading light—just within reach.");
                        Console.WriteLine("It’s a long drop. You might make it... or you might not.");
                        Console.WriteLine("Do you take the leap, or retreat back into the tower?");
                        Console.WriteLine();
                        Console.Write(">> ");

                        string playerChoice = Console.ReadLine().ToLower();

                        switch (playerChoice)
                        {
                            case "jump":
                            case "leap":
                            case "jump off":
                            case "leap off":
                                Console.WriteLine();
                                Console.WriteLine("You take a deep breath, close your eyes—and leap.");
                                Console.WriteLine("The air roars in your ears. For a moment, it feels like flying...");
                                Console.WriteLine("Then everything fades to black.");
                                Console.WriteLine();
                                roomChoice = 9998;
                                jump = true;                               
                                return;
                            case "go down":
                            case "down":
                            case "back":
                            case "return":
                                Console.WriteLine("You turn away from the edge, heart pounding. Not today.");
                                towerFloor--;
                                break;
                            default:
                                Console.WriteLine("The wind howls, waiting for your choice...");
                                break;
                        }
                    }
                }
            }
            static void GoBack()
            {
                Console.WriteLine("You cast a final glance at your surroundings before slipping away.");
                Console.WriteLine("Every step echoes your decision to return the way you came.");
                Console.WriteLine();
                Thread.Sleep(1000);
            }
            static void inventoryShow()//Albert
            {
                string action;
                Console.WriteLine("====================");
                Console.WriteLine("Items in inventory");
                foreach (string item in inv)
                {
                    Console.WriteLine(item);
                }
                Console.WriteLine("====================");
                Console.WriteLine("");
                Console.WriteLine($"{playerWeapon.name}\nDamage {playerWeapon.minDamage}-{playerWeapon.maxDamage}\nBlock Strength {playerWeapon.block}\nStamina cost {playerWeapon.staminaCost}");
                Console.WriteLine("");
                Console.WriteLine("====================");
            Console.WriteLine("Is there anything you want to do with your items eg heal or read notes");
            action = Console.ReadLine().ToLower();
            if (action == "heal")
            {
                Console.WriteLine("do you want to heal health or stamina");
                do
                {
                    action = Console.ReadLine().ToLower();
                    if (action == "stamina")
                    {
                        if (inv.Contains("energy stim"))
                        {
                            stamina += 25;
                            inv.Remove("energy stim");
                        }
                        else
                        {
                            Console.WriteLine("you dont have any energy stims");
                        }
                    }
                    else if (action == "health")
                    {
                        if (inv.Contains("health potion"))
                        {
                            health += 25;
                            inv.Remove("health potion");
                        }
                        else
                        {
                            Console.WriteLine("you don't have any health potions");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Please enter **Health** or **Stamina**");
                    }
                } while (action != "health" && action != "stamina");
            }
            else if (action == "read note" || action == "read"|| action == "read notes") {
                Console.WriteLine("what note do yo want to read");
                action = Console.ReadLine().ToLower();
                    readNote(action);
                }
            Console.Clear();
            }
            
            static void pickup(ref string[] items)//pickup items
            {
                Console.Clear();
                string item = "";

                Console.WriteLine("what item do you want to pick up");
                foreach (string i in items)
                {
                    Console.WriteLine(i);
                }
                item = Console.ReadLine().ToLower().Trim();
                if (items.Contains(item) == true)
                {
                    inv.Add(item);
                    items = items.Where(x => x != item).ToArray();

                }
                else if (item == "all")
                    {
                        foreach (string i in items)
                        {
                            inv.Add(i);
                            items = items.Where(x => x != i).ToArray();
                        }
                    }
                else
                {
                    Console.WriteLine("item not exists");
                }
                Console.WriteLine($"you picked up {item}");
                Thread.Sleep(1000);
            }
            static void showCommands()
            {
                Console.WriteLine("***************************************************************************");
                Console.WriteLine("Type one of the following commands or select a room: \nshow inventory \nshow energy \nsearch \nmap \n");
                Console.WriteLine("***************************************************************************\n\n");
            }
            static void showEnergyLevels()
            {
                Console.WriteLine("***************************************************************************");
                Console.WriteLine($"Health: {health} \nStamina: {stamina}");
                Console.WriteLine("***************************************************************************\n\n");
            }
            static void showMap()
            {
                Console.WriteLine($"........................                              ........................                              ........................\r\n..                    ..                              ..                    ..                              ..                    ..\r\n..      {roomsVisited[0]}          ..................................      {roomsVisited[1]}       ..................................      {roomsVisited[3]}       ..\r\n..                    ..................................                    ..................................                    ..\r\n..                    ..                              ..                    ..                              ..                    ..\r\n........................                              ........................                              ........................\r\n          ...                                                   ....                                                  ...           \r\n          ...                                                    ..                                                    ..           \r\n          ...                                                    ..                                                    ..           \r\n          ...                                                    ..                                                    ..           \r\n          ...                                                    ..                                                    ..           \r\n          ...                                                    ..                                                    ..           \r\n          ...                                                    ..                                                    ..           \r\n          ...                                                    ..                                                    ..           \r\n          ....                                                  ....                                                  ...           \r\n........................   ........................  ........................                              ........................\r\n..                    ..   ..                    ..  ..                    ..                              .                     ..\r\n..       {roomsVisited[2]}       .......      {roomsVisited[5]}       ..  ..   {roomsVisited[4]}  ..                              .        {roomsVisited[7]}       ..\r\n..                    .......                    ..  ..                    ..                              .                     ..\r\n..                    ..   ..                    ..  ..                    ..                              .                     ..\r\n........................   ........................  ........................                              ........................\r\n          ....                   ....                   .....       ....                                              ...          \r\n          ...                     ..                   ....         ...                                                ..          \r\n          ...                     ..                 ....          ...                                                 ..          \r\n          ...                     ..                ..            ..                                                   ..          \r\n          ...                     ..              ..             ..                                                    ..          \r\n          ...                     ..            ...             ...                                                    ..          \r\n          ....                   ....        .....             ..                                                      ..           \r\n........................   .........................          ...                                           ........................\r\n..                    ..   ...                    ..        ....                                            .                     ..\r\n..         {roomsVisited[6]}        ..   ...    {roomsVisited[8]}       ....     ....                                             .      {roomsVisited[10]}      ..\r\n..                    ..   ...                    ...........................................................                     ..\r\n..                    ..   ...                    ..     ...                                                .                     ..\r\n........................   .........................    ...                                               ..........................\r\n           ....                                       ....                                             ......   ....        ....\r\n            ....                                     ....                                          .......     ...           ...\r\n              ....                                  ....                                       .......        ...             ...\r\n               ....                                 ..                                      ......           ...               ...\r\n                 ....                              ..                                   ......              ...                ...\r\n                   ....                          ...                                .......                 ..                  ...\r\n                    ...                         ...                             .......                    ..                    ...\r\n                      ...                      ....                          ......                       ..                      ...\r\n                       ...                    ...                        ......                          ..                       ....\r\n                        ....                 ...                     .......                            ...                        ...\r\n                         ....              ....                   ......                               ....                         ...\r\n                           .... ........................      ......                        ........................      ........................\r\n                             .....                    ..  .......                           .                     ..      ..                    ..\r\n                              ....   {roomsVisited[9]}    .........                             .      {roomsVisited[12]}     ..      ..     {roomsVisited[11]}     ..\r\n                                ..                    ....                                  .                     ..      ..                    ..\r\n                                ..                    ..                                    ..                    ..      ..                    ..\r\n                                ........................                                    ........................      ........................");
            }
            //resets all the variables, lists, .... to restart the game
            static void reset()
            {
                roomChoice = 1;
                health = 100;
                stamina = 100;
                prev = 1;
                sleepCounter = 0;
                inv.Clear();
            labItems = new string[] { "energy stim", "health potion" };
                infirmaryItems = new string[] { "health potion", "energy stim", "note" };
                roomsVisited = new string[] { "?", "???????", "??????", "???????", "???????????????", "???????", "???", "??????", "?????????", "?????????????", "?????????", "??????????", "??????????" };
            }
        static void weaponEquip(string name,int minDmg,int maxDmg,int block,int stamCost)
        {
            playerWeapon.name = name;
            playerWeapon.minDamage = minDmg;
            playerWeapon.maxDamage = maxDmg;
            playerWeapon.block = block;
            playerWeapon.staminaCost = stamCost;
        }
        static void readNote(string noteName)
        {
            switch(noteName){
                case "lab note":
                case "lab":
                    Console.WriteLine("Gaol Infirmary Record\r\n\r\nPrisoner: John of Waltham\r\nOffense: Theft of wool\r\nSentence: Imprisonment until the next assizes\r\nAdmission Date: Feast of St. Michael, Year of Our Lord 1352\r\nSymptoms:\r\n\r\nHigh fever\r\n\r\nPersistent cough\r\n\r\nSwelling of the legs\r\n\r\nDelirium\r\n\r\nDiagnosis: Likely ague or consumption\r\n\r\nTreatment Administered:\r\n\r\nHerbal infusion of elderflower and yarrow to induce perspiration\r\n\r\nApplication of a mustard poultice to the chest to relieve congestion\r\n\r\nHoly water administered thrice daily\r\n\r\nPrayers for healing, including the recitation of the Salve Regina\r\n\r\nDiet of broths and pottage; abstinence from meat\r\n\r\nSpiritual Care: Confession and absolution granted; candle placed at bedside\r\n\r\nPrognosis: Condition remains grave; continued prayers are requested\r\n\r\nAttending Healer: Brother Thomas, infirmarer");
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("you do not have that note");
                    break;
                }
                
        }
        static string combat(int enemyHealth, int enemyDef, int enemyMin, int enemyMax)
        {
            int userDamage, userDefence, enemyDamage;
            Random rand = new Random();
            string combatChoice = "";
            Console.WriteLine("You have entered combat");
            while (health > 0 && stamina > 0 && combatChoice != "run" && enemyHealth > 0)
            {
                if (health < 10) {
                    Console.WriteLine("Warning low health");
                }
                if (stamina < 10) { 
                 Console.WriteLine("Warning low Stamina");
                }

                userDefence = 0;
                Console.WriteLine("What action do you want to take ");

                Console.WriteLine("- Attack");
                Console.WriteLine("- Defend");
                Console.WriteLine("- Run");
                Console.WriteLine("- Heal");
                Console.WriteLine("- Status");
                Console.WriteLine();
                Console.Write(">> ");

                combatChoice = Console.ReadLine().ToLower();
                switch (combatChoice)
                {

                    case "attack"://might add heavy and light attacks
                    case "defend":
                        if (combatChoice == "attack")
                        {
                            userDamage = rand.Next(playerWeapon.minDamage, playerWeapon.maxDamage) - enemyDef;
                            stamina = stamina - playerWeapon.staminaCost;
                            if (userDamage > 0)
                            {
                                Console.WriteLine($"You dealt {userDamage} to the enemy");
                                enemyHealth = enemyHealth - userDamage;
                            }
                            else
                            {
                                Console.WriteLine("your attack was blocked");
                            }
                        }
                        else if (combatChoice == "defend")
                        {
                            Console.WriteLine("you braced for the attack");
                            userDefence = playerWeapon.block;
                            userDamage = playerWeapon.minDamage - enemyDef;
                            stamina = stamina - playerWeapon.staminaCost;
                            if (userDamage > 0)
                            {
                                Console.WriteLine($"You dealt {userDamage} to the enemy");
                                enemyHealth = enemyHealth - userDamage;
                            }
                            else
                            {
                                Console.WriteLine("your attack was blocked");
                            }
                        }
                        enemyDamage = rand.Next(enemyMin, enemyMax) - userDefence;
                        if (enemyDamage > 0)
                        {
                            health = health - enemyDamage;
                            Console.WriteLine($"The enemy dealt {enemyDamage} you have {health} remaining");
                        }
                        break;
                    case "heal":
                        Console.WriteLine("do you want to heal health or stamina");
                        do
                        {
                            combatChoice = Console.ReadLine().ToLower();
                            if (combatChoice == "stamina")
                            {
                                if (inv.Contains("energy stim"))
                                {
                                    stamina += 25;
                                    inv.Remove("energy stim");
                                }
                                else
                                {
                                    Console.WriteLine("you dont have any energy stims");
                                }
                            }
                            else if (combatChoice == "health")
                            {
                                if (inv.Contains("health potion"))
                                {
                                    health += 25;
                                    inv.Remove("health potion");
                                }
                                else
                                {
                                    Console.WriteLine("you don't have any health potions");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Please enter **Health** or **Stamina**");
                            }
                        } while (combatChoice != "health" && combatChoice != "stamina");
                        break;

                    case "status":
                        showEnergyLevels();
                        Console.WriteLine($"Enemy Health Remaining {enemyHealth}");
                        Console.WriteLine("***************************************************************************\n\n");
                        break;
                    case "run":
                        break;
                    case "show inventory":
                    case "inv":
                        inventoryShow();
                        break;
                    default:
                        Console.WriteLine("Please enter a valid input either\n**Attack**\n**Defend**\n**Run**\n**Heal**\n**Show Inventory**");
                        break;
                    

                }
            }
            if (enemyHealth <= 0) {
                Console.WriteLine("YOU WIN");
                Thread.Sleep(1000);
                return "win"; }
            else { 
                Console.WriteLine("YOU LOSE");
                Thread.Sleep(1000);
                health = 50;
                Console.WriteLine("you regain some health");
                return "lose"; }
        }
        static void WriteCentered(string message)
        {
            int left = (Console.WindowWidth - message.Length) / 2;
            Console.SetCursorPosition(left, Console.CursorTop);
            Console.WriteLine(message);
        }

    }
}

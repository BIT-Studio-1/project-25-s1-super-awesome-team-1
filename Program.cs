using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using static System.Formats.Asn1.AsnWriter;

namespace Studio1Project
{
    internal class Program
    {
        private static int roomChoice,heath=100,stamina=100,prev = 1, sleepCounter = 0;
        private static string action = "";
        private static List<string> inv = new List<string>();
        private static string[] infirmaryItems = { "health potion", "energy stim", "note" };
        private static string[] cellItems = { "cell keys" };
        static void Main(string[] args)
        {
            Console.WriteLine("welcome to the game");
            PrisonCell();
            do
            {
                
                switch (roomChoice)
                {
                    
                    case 1:
                        PrisonCell();
                        break;
                    case 2:
                        DungeonHall();
                        break;
                    case 3:
                        Sewers();
                        break;
                    case 4:
                        Kitchen();
                        break;
                    case 5:
                        GuardsBarracks();
                        break;
                    case 6:
                        Showers();
                        break;
                    case 7:
                        Lab(); 
                        break;
                    case 8:
                        Pantry();
                        break;
                    case 9:
                        Infirmary();
                        break;
                    case 10:
                        TrainingYard();
                        break;
                    case 11:
                        Courtyard();
                        break;
                    case 12:
                        GateHouse();
                        break;
                    case 13:
                        TowerBase();
                        break;

                }
            }while (roomChoice != 9999);
        }

            //All of the rooms 
            static void PrisonCell()//room 1 (main room)
        {
            Console.WriteLine("You wake up in a prison cell.");
            
            bool validInput = false;
            while (!validInput)
            {
                Console.WriteLine("A guard snores loudly just outside, slouched in a wooden chair, keys hanging loosely from his belt.");
                Console.WriteLine("As you scan the cell, you notice a loose stone at the back wall. Behind it, there's a faint draft—it must lead to the sewers.");
                action = Console.ReadLine().ToLower();

                switch (action)
                {
                    case "hall":
                    case "halll":
                    case "open cell":
                        if (inv.Contains("cell keys"))
                        {
                            roomChoice = 2;
                            validInput = true;
                        }
                        else
                        {
                            Console.WriteLine("Your cell is locked! You cannot enter the hall.");
                            roomChoice = 1;
                        }
                        break;
                    case "sewers":
                        roomChoice = 3;
                        validInput = true;
                        break;
                    case "back":
                        roomChoice = prev;
                        validInput = true;
                        break;
                    case "test":
                        roomChoice = Convert.ToInt32(Console.ReadLine());
                        validInput = true;
                        break;
                    case "pickup":
                        pickup(ref cellItems);
                        break;
                    case "help":
                        showCommands();
                        break;
                    case "sleep":
                        //include energy increase
                        Console.WriteLine("You lie back on the cold stone floor and close your eyes. Despite the discomfort, you manage to rest.");
                        Thread.Sleep(2000);
                        Console.WriteLine("Sleeping helped you regain some energy!!");
                        sleepCounter = sleepCounter + 1;
                        if (sleepCounter > 10)
                        {
                            Console.WriteLine("You win!");
                            roomChoice = 9999;
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
            Console.WriteLine("You quietly step into the dimly lit dungeon hall.");
            

            bool validInput = false;
            while (!validInput)
            {
                Console.WriteLine("Shadows stretch along the damp stone corridor, torches flickering weakly in rusted sconces.");
                Console.WriteLine("To your left, heavy boots echo faintly from the guard barracks. Ahead, the scent of stale broth and overcooked meat wafts from the kitchen.");
                Console.WriteLine("Behind you, your cell waits — but that’s not a place you want to return to.");
                action = Console.ReadLine().ToLower();
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
                        roomChoice = prev;
                        validInput = true;
                        break;
                    case "help":
                        showCommands();
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
            Console.WriteLine("To your **left**, the tunnel narrows into a tiled area where water drips steadily — it sounds like an old washroom.");
            Console.WriteLine("To your **right**, faint lights flicker behind a rusted iron grate, and a sharp chemical odor hangs in the air.");
            Console.WriteLine("Behind you is the tunnel you crawled through to get here.");
            action = Console.ReadLine().ToLower();
            switch (action)
            {
                case "cell":
                case "celll":
                    prev = roomChoice;
                    roomChoice = 1;
                    break;
                case "showers":
                case "showerss":
                case "left":
                case "washroom":
                case "wash room":
                    prev = roomChoice;
                    roomChoice =6;
                    break;
                case "lab room":
                case "labroom":
                case "right":
                    prev = roomChoice;
                    roomChoice = 7;
                    break;
                case "back":
                case "return":
                case "tunnel":
                    roomChoice = prev;
                    break;
                case "help":
                    showCommands();
                    roomChoice = 3;
                    break;
                case "show energy":
                    showEnergyLevels();
                    roomChoice = 3;
                    break;
                case "show inventory":
                case "inv":
                    inventoryShow();
                    roomChoice = 3;
                    break;
                default:
                    Console.WriteLine("Try something else!");
                    roomChoice = 3;
                    break;
            }
        }
        static void Kitchen()//Room4
        {
            Console.WriteLine("You step into the prison kitchen. Grease stains mark the floor, and a single pot boils unattended, filling the air with a sour, meaty smell.");
            Console.WriteLine("To your left, a narrow door leads to what looks like a pantry — you hear muffled movement inside.");
            Console.WriteLine("Behind you is the corridor leading back to the dungeon hall.");
            action = Console.ReadLine().ToLower();
            switch (action)
            {
                case "dungeon hall":
                    prev = roomChoice;
                    roomChoice = 2;
                    break;
                case "pantry storage":
                case "left":
                    prev = roomChoice;
                    roomChoice = 8;
                    break;
                case "back":
                case "return":
                    roomChoice = prev;
                    break;
                case "help":
                    showCommands();
                    roomChoice = 4;
                    break;
                case "show energy":
                    showEnergyLevels();
                    roomChoice = 4;
                    break;
                case "show inventory":
                case "inv":
                    inventoryShow();
                    roomChoice = 4;
                    break;
                default:
                    Console.WriteLine("Try something else!");
                    roomChoice = 4;
                    break;
            }
        }
        static void GuardsBarracks()//Room5 SSSSSSS
        {
            Console.WriteLine("You push the heavy wooden door open. It groans on rusted hinges, but the corridor beyond remains silent.");
            Console.WriteLine("The barracks are dim. Torches flicker low, casting restless shadows that dance across rows of unmade bunks and battered lockers.");
            Console.WriteLine("The smell hits you first — sweat, oil, and something long past edible. A half-eaten loaf lies beside a dented helmet.");
            Console.WriteLine("You see no guards... but the clutter tells you they were here not long ago.");
            Console.WriteLine();

            bool validInput = false;
            while (!validInput)
            {
                Console.WriteLine("There are two doors: one marked with the red cross of the **Infirmary**, the other leads out to the **Training Yard**.");
                Console.WriteLine("You could also take a moment to look around the barracks.");
                Console.WriteLine();
                Console.WriteLine("What do you do?");
                Console.WriteLine("- Go to Infirmary");
                Console.WriteLine("- Go to Training Yard");
                Console.WriteLine("- Search Room");
                Console.WriteLine("- Go Back");
                Console.WriteLine();

                action = Console.ReadLine().ToLower();

                switch (action)
                {
                    case "infirmary":
                    case "go to infirmary":
                        prev = roomChoice;
                        roomChoice = 9;
                        validInput = true;
                        break;
                    case "training yard":
                    case "go to training yard":
                    case "t/y":
                        prev = roomChoice;
                        roomChoice = 10;
                        validInput = true;
                        break;
                    case "back":
                    case "go back":
                        roomChoice = prev;
                        validInput = true;
                        break;
                    case "search room":
                    case "search":
                        Console.WriteLine();
                        Console.WriteLine("You sift through the mess. Most of it is junk—empty bottles, broken gear...");
                        Console.WriteLine("But tucked under a thin mattress, you find a dusty but intact **Guard’s Uniform**. Might come in handy for blending in.");
                        Console.WriteLine("Type 'show inventory' to check what you're carrying.");
                        Console.WriteLine();
                        break;
                    case "show inventory":
                    case "inv":
                        inventoryShow();
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
            Console.WriteLine();
            Console.WriteLine("As you climb the slimy ladder, you emerge into the old prison showers. The stone floor is slick with moss, and water still drips from rusted pipes overhead.");
            Console.WriteLine("The air is cold and smells.");
            Console.WriteLine("You hear a faint shuffling sound echoing down the tiled corridor, but when you look, there’s nothing there.");
            Console.WriteLine();

            action = Console.ReadLine().ToLower();
            switch (action)
            {
                case "infirmary":
                    prev = roomChoice;
                    roomChoice = 9;
                    break;             
                case "back":
                    roomChoice=prev;
                    break;
                case "show inventory":
                    inventoryShow();
                    break;
            }
        }
        static void Lab()//Room7 SSSSSSSSSSSSSSSSSSS
        {
            Console.WriteLine();
            Console.WriteLine("you made it to the Lab \n do you want to go to the Training yard or Go Back");
            action = Console.ReadLine().ToLower();
            switch (action)
            {
                case "training yard":
                    prev = roomChoice;
                    roomChoice = 10;
                    break;
                case "back":
                    roomChoice = prev;
                    break;
            }
        }
        static void Pantry()//Room8 Albert
        {
            Console.WriteLine("You entered the pantry you can got to the \nkitchen \ncourtyard\n or back");
            action = Console.ReadLine().ToLower();
            switch (action)
            {
                case "kitchen":
                    prev= roomChoice;
                    roomChoice = 4;
                    break;
                case "courtyard":
                    prev = roomChoice;
                    roomChoice = 11;
                    break;
                case "back":

                    break;
            }
        }
        static void Infirmary()//Room9 Albert
        {
           
            Console.WriteLine("You entered the Infirmary you can got to the \ngaurdbarracks \nshowers\n courtyard  \n or back");
            action = Console.ReadLine().ToLower();
            switch (action)
            {
                case "pickup":
                    pickup(ref infirmaryItems);
                    break;
                case "show":
                    inventoryShow();
                    break;
                case "guardbarracks":
                    prev = roomChoice;
                    roomChoice = 5;
                    break;
                case "showers":
                    prev = roomChoice;
                    roomChoice = 6;
                    break;
                case "courtyard":
                    prev = roomChoice;
                    roomChoice = 11;
                    break;
                case "back":
                    roomChoice = prev;
                    break;
            }
        }

        static void TrainingYard()//Room10 Albert
        {
                Console.WriteLine("You entered the Training Yard you can got to the \ngaurdbarracks \nlab\n courtyard  \n or back");
                action = Console.ReadLine().ToLower();
                switch (action)
                {
                    case "lab":
                    prev = roomChoice;
                    roomChoice = 7;
                        break;
                    case "gaurdbarracks":
                        prev = roomChoice;
                        roomChoice = 5;
                        break;
                    case "courtyard":
                        prev = roomChoice;
                        roomChoice = 11;
                        break;
                    case "back":
                        roomChoice= prev;
                        break;
                }
        }
        static void Courtyard()//Room11
        {
            Console.WriteLine("you made it to the Courtyard do you want to go to the \n Gatehouse \nTower base \n Pantry storage \n Infirmary \n Training yard \n or back");
            action = Console.ReadLine().ToLower();
            switch (action)
            {
                case "gatehouse":
                    roomChoice = 12;
                    break;
                case "tower base":
                    roomChoice = 13;
                    break;
                case "pantry storage":
                    roomChoice = 8;
                    break;
                case "infirmary":
                    roomChoice = 9;
                    break;
                case "training yard":
                    roomChoice = 10;
                    break;
            }
        }
        static void GateHouse()//Room12 EXIT
        {
            Console.WriteLine("you made it to the Gatehouse do you want to go to the \n Courtyard \n or back");
            action = Console.ReadLine().ToLower();
            switch (action)
            {
                case "courtyard":
                    roomChoice = 11;
                    break;

                //Needs solution to the exit

            }
        }
        static void TowerBase()//Room13
        {
            Console.WriteLine("you made it to the Towerbase do you want to go to the \n Courtyard \n or back");
            action = Console.ReadLine().ToLower();
            switch (action)
            {
                case "courtyard":
                    roomChoice = 11;
                    break;
            }
        }
        static void inventoryShow()//Albert
        {
            Console.WriteLine("====================");
            Console.WriteLine("Items in inventory");
            foreach (string item in inv )
            {
                Console.WriteLine(item);
            }
        }
        static void pickup(ref string[] items)//pickup items
        {
            Console.Clear();
            string item="";

            Console.WriteLine("what item do you want to pick up");
            foreach (string i in items)
            {
                Console.WriteLine(i);
            }
            item = Console.ReadLine();
            if (items.Contains(item) == true)
            {
                inv.Add(item);
                items = items.Where(x => x != item).ToArray();

            }
            else {
                Console.WriteLine("item not exists");
            }
            Console.WriteLine($"you picked up {item}");
            Thread.Sleep(1000);
        }

        static void showCommands()
        {
            Console.WriteLine("***************************************************************************");
            Console.WriteLine("Type one of the following commands or select a room: \nshow inventory \nshow health");
            Console.WriteLine("***************************************************************************\n\n");
        }

        static void showEnergyLevels()
        {
            Console.WriteLine("***************************************************************************");
            Console.WriteLine($"Health: {heath} \nStamina: {stamina}");
            Console.WriteLine("***************************************************************************\n\n");
        }

        public static void combat()
        {

            int health = 100;
            int stamina = 100;
            int healthcost = 10; //interchangeable amount idk what yet
            int staminacost = 10; //interchangeable amount idk what yet

            while (health > 0 && stamina > 0)
            {
                Console.WriteLine("Do you want to fight (yes/no): ");
                string choice = Console.ReadLine().ToLower();

                if (choice == "yes")
                {
                    if (stamina >= staminacost)
                    {
                        stamina -= staminacost;
                        health -= healthcost;
                        Console.WriteLine("you successfully beat your opponent");
                        Console.WriteLine($"You lost {staminacost} stamina and {healthcost} health.");
                        Console.WriteLine($"You now have {stamina} stamina and {health} health.");
                    }
                    else
                    {
                        Console.WriteLine("not enough stamina");
                    }
                }
                else if (choice == "no")
                {
                    Console.WriteLine("You Choose to flee");
                }
                else
                {
                    Console.WriteLine("Invalid input. Type 'yes' or 'no'.");
                }

                health = Math.Max(0, health);
                stamina = Math.Max(0, stamina);

            }
            Console.WriteLine("You're too tired to fight"); //we should add a way to regain stamina such as food
        }

    }
}

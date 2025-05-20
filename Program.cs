using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace Studio1Project
{
    internal class Program
    {
        private static int roomChoice,heath=100,stamina=100,prev = 1, sleepCounter = 0;
        private static string action = "";
        private static List<string> inv = new List<string>();
        private static string[] infirmaryItems = { "health potion", "energy stim", "note", "Guard's Uniform" };
        static void Main(string[] args)
        {
            Console.WriteLine("welcome to the game"); // ascii art goes here
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
            Console.WriteLine("A guard snores loudly just outside, slouched in a wooden chair, keys hanging loosely from his belt.");
            Console.WriteLine("As you scan the cell, you notice a loose stone at the back wall. Behind it, there's a faint draft—it must lead to the sewers.");
            action = Console.ReadLine().ToLower();

            switch (action)
            {
                case "hall":
                case "halll":
                    roomChoice = 2;
                    break;
                case "sewers":
                    roomChoice =3;
                    break;
                case "back":
                    roomChoice = prev;
                    break;
                case "test":
                    roomChoice = Convert.ToInt32(Console.ReadLine());
                    break;      
                case "help":
                    showCommands();
                    break;
                case "sleep":
                    //include energy increase
                    Console.WriteLine("You lie back on the cold stone floor and close your eyes. Despite the discomfort, you manage to rest.");
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
            }
        }

        static void DungeonHall()//Room 2
        {
            Console.WriteLine("You quietly step into the dimly lit dungeon hall. Shadows stretch along the damp stone corridor, torches flickering weakly in rusted sconces.");
            Console.WriteLine("To your left, heavy boots echo faintly from the guard barracks. Ahead, the scent of stale broth and overcooked meat wafts from the kitchen.");
            Console.WriteLine("Behind you, your cell waits — but that’s not a place you want to return to.");
            action = Console.ReadLine().ToLower();
            switch (action)
            {
                case "cell":
                    prev = roomChoice;
                    roomChoice = 1;
                    break;
                case "guard barracks":
                case "gaurd barracks":
                    prev = roomChoice;
                    roomChoice = 5;
                    break;
                case "kitchen":
                    prev = roomChoice;
                    roomChoice =4;
                    break;
                case "back":
                case "return":
                    roomChoice = prev;
                    break;
            }
        }
        static void Sewers()//room 3
        {
            Console.WriteLine("you made it to the sewers.\n  Where do you want to go next? \n-cell \n-showers \n-lab room \n-back");
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
                    prev = roomChoice;
                    roomChoice =6;
                    break;
                case "lab room":
                case "labroom":
                    prev = roomChoice;
                    roomChoice = 7;
                    break;
                case "back":
                    roomChoice = prev;
                    break;
            }
        }
        static void Kitchen()//Room4
        {
            Console.WriteLine("you made it to room the kitchen.\n Where do you want to go next? \n-dungeon hall \n-pantry storage \n-back");
            action = Console.ReadLine().ToLower();
            switch (action)
            {
                case "dungeon hall":
                    prev = roomChoice;
                    roomChoice = 2;
                    break;
                case "pantry storage":
                    prev = roomChoice;
                    roomChoice = 8;
                    break;
                case "back":
                    roomChoice = prev;
                    break;
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

            bool validInput = false;
            while (!validInput)
            {
                Console.WriteLine("There are two doors: one marked with the red cross of the Infirmary, the other leads out to the Training Yard.");
                Console.WriteLine("You could also take a moment to look around the barracks.");
                Console.WriteLine();

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
                    case "back":
                    case "go back":
                        GoBack();
                        roomChoice = prev;
                        validInput = true;
                        break;
                    case "search room":
                    case "search":
                        Console.WriteLine();
                        Console.WriteLine("You sift through the mess. Most of it is junk—empty bottles, broken gear...");
                        Console.WriteLine("But tucked under a thin mattress, you find a dusty but intact **Guard’s Uniform**. You search the pockets and find a **Key**.");
                        Console.WriteLine("Type 'show inventory' to check what you're carrying.");
                        Console.WriteLine();
                        inv.Add("Gatehouse Key");
                        Thread.Sleep(5000);
                        break;
                    case "show inventory":
                    case "inv":
                        inventoryShow();
                        Thread.Sleep(2000);
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
            Console.Clear();
            Console.WriteLine("You grip the rusted ladder rungs and climb up, feet slipping slightly on the damp metal.");
            Console.WriteLine("A cold draft hits you as you emerge into a crumbling shower room. Water drips steadily from cracked pipes above, echoing through the tiled space.");
            Console.WriteLine("The walls are stained with age and mold, and the sour smell of mildew clings to the air.");
            Console.WriteLine("Light from a window overhead casts strange shadows between the rows of broken stalls.");
            Console.WriteLine();
            Console.WriteLine("Somewhere in the distance, you hear a metallic clang... then silence.");
            Console.WriteLine();

            bool validInput = false;
            while (!validInput)
            {
                Console.WriteLine("There’s a narrow iron door half-hinged open, marked faintly with the red cross of the Infirmary.");
                Console.WriteLine("You could also climb back down into the sewers, if you’d rather not linger here any longer.");
                Console.WriteLine();

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
                    case "go back":
                        Console.WriteLine("You pause for a moment, taking one last look around.");
                        Console.WriteLine("With cautious steps, you retrace your path to the previous area.");
                        Thread.Sleep(1000);
                        roomChoice = prev;
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
                        Thread.Sleep(2000);
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

            

            bool validInput = false;
            while (!validInput)
            {
                Console.WriteLine("There’s a door leading to the Training Yard, its reinforced window cracked but intact.");
                Console.WriteLine("You could also return to the Sewers, retracing your steps through the underground passage.");
                Console.WriteLine();

                action = Console.ReadLine().ToLower();

                switch (action)
                {
                    case "training yard":
                    case "go to training yard":
                    case "goto training yard":
                    case "t/y":
                        prev = roomChoice;
                        roomChoice = 10;
                        break;
                    case "back":
                    case "sewers":
                        GoBack();
                        roomChoice = prev;
                        validInput = true;
                        break;
                }
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
                case "exit":
                    roomChoice = 9999;
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
        static void GoBack()
        {
            Console.WriteLine("You cast a final glance at your surroundings before slipping away.");
            Console.WriteLine("Every step echoes your decision to return the way you came.");
            Console.WriteLine();
            Thread.Sleep(1000);
        }
        static void inventoryShow()//Albert
        {
            Console.WriteLine("====================");
            Console.WriteLine("Items in inventory");
            foreach (string item in inv )
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("====================");
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
            Console.WriteLine("Type one of the following commands or select a room: \nshow inventory \nshow health");
        }

        static void showEnergyLevels()
        {
            Console.WriteLine($"Health: {heath} \nStamina: {stamina}");
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

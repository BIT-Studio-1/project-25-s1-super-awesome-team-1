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
        private static string[] infirmaryItems = { "health potion", "energy stim", "note" };
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
            Console.WriteLine("You wake up in a prison cell \nYou see a sleeping guard sitting on a chair in front of the cell. As you look around, you notice a loose stone in the back leading to the sewers. do you want to go to \n- hall \n- sewers");
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
            Console.WriteLine("you made it the dungeon hall.\n Where do you want to go next? \n-cell \n-guard barracks \n-kitchen \n-back");
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
            Console.WriteLine();
            Console.WriteLine("You ease the heavy door open with a creak. Inside, the Guards’ Barracks are dimly lit, with flickering torches casting long shadows over the rows of bunk beds.");
            Console.WriteLine("The smell of sweat and steel clings to the air. Swords, armor pieces, and half-eaten food lie scattered across the room.");
            Console.WriteLine("It seems the guards left in a hurry—or didn’t leave at all.");
            Console.WriteLine();
            Console.WriteLine("You notice two exits: a reinforced door leading to the **Training Yard**, and another to the **Infirmary**.");
            Console.WriteLine("What do you do?");
            Console.WriteLine("- go to infirmary");
            Console.WriteLine("- go to training yard");
            Console.WriteLine("- search room");
            Console.WriteLine("- go back");

            action = Console.ReadLine().ToLower();
                        
            switch (action) 
            {
                case "infirmary":
                case "go to infirmary":
                    prev = roomChoice;
                    roomChoice = 9;
                    break;
                case "training yard":
                case "go to training yard":
                    prev = roomChoice;
                    roomChoice = 10;
                    break;
                case "back":
                case "go back":
                    roomChoice = prev;
                    break;
                case "search room":
                    Console.WriteLine("On one of the beds, you spot a mostly-intact **Guard’s Uniform**. Might come in handy.");
                    break;
                case "show inventory":
                    inventoryShow();
                    break;
                default:
                    Console.WriteLine("You pause for a moment, listening. Was that a footstep?");
                    break;
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

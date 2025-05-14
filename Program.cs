using System.Reflection;
using System.Runtime.Versioning;

namespace Studio1Project
{
    internal class Program
    {
        private static int roomChoice,heath=100,stamina=100,prev = 1;
        private static string action = "";
        private static List<string> inv = new List<string>();
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

        // Dictionary for rooms
        static Dictionary<string, string[]> rooms = new Dictionary<string, string[]>
    {
        { "hallway", new string[] { "hallway", "corridor", "passage", "hall", "h/y" } },
        { "sewers", new string[] { "sewers", "drain", "underground" } },
        { "library", new string[] { "library", "books", "study", "" } },
        { "dungeon", new string[] { "dungeon", "prison", "jail", "cell", "start" } },
        { "showers", new string[] { "shower", "shwer", "shwr", "sh" } },
        { "lab", new string[] { "lab", "labs", "laboratory", "labrm", "l/r" } },
        { "infirmary", new string[] { "infirmary", "infrm", "medical", "meds", "hospital", "clinic", "sick bay", "sickbay", "med bay", "first aid", "doctor", "doc" } },
        { "guard barracks", new string[] { "guard", "barracks", "garrison", "security", "guards", "barrack", "watchmen", "g/b" } },
        { "kitchen", new string[] { "kitchen", "cooking", "galley", "pantry", "mess", "k/c" } },
        { "training yard", new string[] { "training yard", "drill", "practice", "exercise", "training", "yard", "t/y" } },
        { "tower", new string[] { "tower", "watchtower", "spire", "lookout" } },
        { "courtyard", new string[] { "courtyard", "plaza", "quad", "c/y" } },
        { "gatehouse", new string[] { "gatehouse", "gate", "gateway", "finish" } },
    };

        // Method for processing user input
        static void ProcessCommand(string input)
        {
            foreach (var room in rooms)
            {
                if (room.Value.Any(keyword => input.Contains(keyword)))
                {
                    Console.WriteLine($"You move to the {room.Key}.");
                    return; // Exit after finding the room
                }
            }


            //All of the rooms 
            static void PrisonCell()//room 1 (main room)
        {
            Console.WriteLine("you made it to room 1 \n do you want to go to room 2 or 3");
            action = Console.ReadLine().ToLower();
            switch (action)
            {
                case "hall":
                    roomChoice = 2;
                    break;
                case "sewers":
                    roomChoice =3;
                    break;

            }
        }

        static void DungeonHall()//Room 2
        {
            Console.WriteLine("you made it the dungeon hall.\n Where do you want to go next?");
            action = Console.ReadLine().ToLower();
            switch (action)
            {
                case "cell":
                    prev = roomChoice;
                    roomChoice = 1;
                    break;
                case "guard barracks":
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
            Console.WriteLine("you made it to the sewers.\n  Where do you want to go next? cell, showers, lab room or back");
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
            Console.WriteLine("you made it to room the kitchen.\n Where do you want to go next? dungeon hall, pantry storage or back");
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
            Console.WriteLine("you made it to the Guards Barracks \n do you want to go to the Training Yard or Infirmary or Go Back");
            action = Console.ReadLine().ToLower();
            switch (action)
            {
                case "infirmary":
                case "Infirmary":
                case "infrmry":
                case "infirm":
                case "doctor":
                    prev = roomChoice;
                    roomChoice = 9;
                    break;
                case "Training Yard":
                case "trainingyard":
                case "training yard":
                case "trainyard":
                    prev = roomChoice;
                    roomChoice = 10;
                    break;
                case "Go back":
                case "back":
                case "Back":
                    roomChoice = prev;
                    break;
            }
        }
        static void Showers()//Room6 SSSSSSSSSSSSSSSSS
        {
            Console.WriteLine();
            Console.WriteLine("you made it to the Showers \n do you want to go to the Infirmary or Go Back");
            action = Console.ReadLine().ToLower();
            switch (action)
            {
                case "infirmary":
                case "Infirmary":
                case "infrmry":
                case "infirm":
                case "doctor":
                    prev = roomChoice;
                    roomChoice = 9;
                    break;
                case "go back":
                case "Back":
                case "back":
                case "Go Back":
                    roomChoice=prev;
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
                case "Training yard":
                case "Trainingyard":
                case "TrainingYard":
                case "trainingyard":
                case "training yard":
                case "yard":
                case "Yard":
                    prev = roomChoice;
                    roomChoice = 10;
                    break;
                case "Back":
                case "back":
                case "Go Back":
                case "go back":
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
            Console.WriteLine("You entered the Infirmary you can got to the \nguardbarracks \nshowers\n courtyard  \n or back");
            action = Console.ReadLine().ToLower();
            switch (action)
            {
                case "pickup":
                    if (inv.Contains("health Potion") == false)
                    {
                        inv.Add("health Potion");
                    }
                    else
                    {
                        Console.WriteLine("you have already picked up the potion");
                    }
                    
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
            Console.WriteLine("you made it to room 11 \n do you want to go to room 13, 14, 8, 9 or 10");
            action = Console.ReadLine().ToLower();
            switch (action)
            {
                case "Gatehouse":
                    roomChoice = 13;
                    break;
                case "Tower Base":
                    roomChoice = 14;
                    break;
                case "Pantry Storage":
                    roomChoice = 8;
                    break;
                case "Infirmary":
                    roomChoice = 9;
                    break;
                case "Training Yard":
                    roomChoice = 10;
                    break;
            }
        }
        static void GateHouse()//Room12 EXIT
        {
            Console.WriteLine("");
            roomChoice = 9999;
        }
        static void TowerBase()//Room13
        {
            Console.WriteLine("");
            roomChoice = Convert.ToInt32(Console.ReadLine());
        }

        static void inventoryShow()//Albert
        {
            foreach (string item in inv )
            {
                Console.WriteLine(item);
            }
        }

    }
}

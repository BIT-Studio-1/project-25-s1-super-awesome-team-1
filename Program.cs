namespace Studio1Project
{
    internal class Program
    {
        private static int roomChoice,heath=100,stamina=100;
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




        //All of the rooms 
        static void PrisonCell()//room 1 (main room)
        {
            Console.WriteLine("you made it to room 1 \n do you want to go to room 2 or 3");
            action = Console.ReadLine();
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
            Console.WriteLine("you made it the dungeon hall. Where do you want to go next?");
            action = Console.ReadLine();
            switch (action)
            {
                case "cell":
                    roomChoice = 1;
                    break;
                case "guard barracks":
                    roomChoice = 5;
                    break;
                case "kitchen":
                    roomChoice =4;
                    break;
            }
        }
        static void Sewers()//room 3
        {
            Console.WriteLine("you made it to room 3 \n do you want to go to room 2 or 3");
            roomChoice = Convert.ToInt32(Console.ReadLine());
        }
        static void Kitchen()//Room4
        {
            Console.WriteLine("you made it to room 2 \n do you want to go to room 2 or 3");
            roomChoice = Convert.ToInt32(Console.ReadLine());
        }
        static void GuardsBarracks()//Room5 SSSSSSS
        {
            Console.WriteLine();
            Console.WriteLine("you made it to room 5 \n do you want to go to room 9 or 10");
            action = Console.ReadLine();
            switch (action)
            {
                case "infirmary":
                case "Infirmary":
                case "infrmry":
                case "infirm":
                case "doctor":
                    roomChoice = 9;
                    break;
                case "Training Yard":
                case "trainingyard":
                case "training yard":
                case "trainyard":
                    roomChoice = 10;
                    break;
            }
        }
        static void Showers()//Room6 SSSSSSSSSSSSSSSSS
        {
            Console.WriteLine();
            Console.WriteLine("you made it to room _ \n do you want to go to room _ or _");
            action = Console.ReadLine();
            switch (action)
            {
                case "infirmary":
                case "Infirmary":
                case "infrmry":
                case "infirm":
                case "doctor":
                    roomChoice = 9;
                    break;
                case "go back":
                case "Back":
                case "back":
                case "Go Back":

                    break;
            }
        }
        static void Lab()//Room7 SSSSSSSSSSSSSSSSSSS
        {
            Console.WriteLine();
            Console.WriteLine("you made it to the Lab \n do you want to go to the\nTraining yard\nGo back");
            action = Console.ReadLine();
            switch (action)
            {
                case "Training yard":
                case "Trainingyard":
                case "TrainingYard":
                case "trainingyard":
                case "training yard":
                case "yard":
                case "Yard":
                    roomChoice = 10;
                    break;
                case "Back":
                case "back":
                case "Go Back":
                case "go back":
                    
                    break;
            }
        }
        static void Pantry()//Room8
        {
            Console.WriteLine("");

            roomChoice = Convert.ToInt32(Console.ReadLine());
        }
        static void Infirmary()//Room9
        {
            Console.WriteLine("");
            roomChoice = Convert.ToInt32(Console.ReadLine());
        }
        static void TrainingYard()//Room10
        {
            Console.WriteLine("");
            roomChoice = Convert.ToInt32(Console.ReadLine());
        }
        static void Courtyard()//Room11
        {
            Console.WriteLine("");
            roomChoice = Convert.ToInt32(Console.ReadLine());
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

    }
}

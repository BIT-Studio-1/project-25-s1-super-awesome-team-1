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
            Console.WriteLine("you made it to room 2 \n do you want to go to room 2 or 3");
            roomChoice = Convert.ToInt32(Console.ReadLine());
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
        static void GuardsBarracks()//Room5
        {
            Console.WriteLine("");
            roomChoice = Convert.ToInt32(Console.ReadLine());
        }
        static void Showers()//Room6
        {
            Console.WriteLine("");
            roomChoice = Convert.ToInt32(Console.ReadLine());
        }
        static void Lab()//Room7
        {
            Console.WriteLine("");
            roomChoice = Convert.ToInt32(Console.ReadLine());
        }
        static void Pantry()//Room8 Albert
        {
            Console.WriteLine("");
            action = Console.ReadLine();
            switch (action)
            {
                case "kitchen":
                    roomChoice = 4;
                    break;
                case "courtyard":
                    roomChoice = 11;
                    break;
                case "back":
                    break;
        }
        static void Infirmary()//Room9 Albert
        {
                Console.WriteLine("");
                action = Console.ReadLine();
                switch (action)
                {
                    case "gaurdbarracks":
                        roomChoice = 5;
                        break;
                    case "showers":
                        roomChoice = 6;
                        break;
                    case "courtyard":
                        roomChoice = 11;
                        break;
                    case "back":
                        break;
                }

                static void TrainingYard()//Room10 Albert
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

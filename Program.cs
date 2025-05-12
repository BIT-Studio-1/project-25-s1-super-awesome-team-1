namespace Studio1Project
{
    internal class Program
    {
        private static int roomChoice,heath=100,stamina=100;
        private static List<string> inv = new List<string>();
        static void Main(string[] args)
        {
            Console.WriteLine("welcome to the game");
            prisonCell();
            do
            {
                switch (roomChoice)
                {

                    case 1:
                        prisonCell();
                        break;
                    case 2:
                        dungeonHall();
                        break;
                    case 3:
                        sewers();
                        break;


                }
            }while (roomChoice != 9999);
        }
        static void prisonCell()//room 1 (main room)
        {
            Console.WriteLine();
            Console.WriteLine("you made it to room 1 \n do you want to go to room 2 or 3");
            roomChoice = Convert.ToInt32(Console.ReadLine());
        }

        static void dungeonHall()//
        {
            Console.WriteLine("you made it to room 2 \n do you want to go to room 2 or 3");
            roomChoice = Convert.ToInt32(Console.ReadLine());
        }
        static void sewers()//room 3
        {
            Console.WriteLine("you made it to room 3 \n do you want to go to room 2 or 3");
            roomChoice = Convert.ToInt32(Console.ReadLine());
        }
        static void kitchen()//Room4
        {
            Console.WriteLine("");
        }
        static void gaurdsBarracks()//Room5
        {
            Console.WriteLine("");
        }
        static void showers()//Room6
        {
            Console.WriteLine("");
        }
        static void lab()//Room7
        {
            Console.WriteLine("");
        }
        static void pantry()//Room8
        {
            Console.WriteLine("");
        }
        static void infirmary()//Room9
        {
            Console.WriteLine("");
        }
        static void trainingYard()//Room10
        {
            Console.WriteLine("");
        }
        static void Courtyard()//Room11
        {
            Console.WriteLine("");
        }
        static void GateHouse()//Room12 EXIT
        {
            Console.WriteLine("");
        }
        static void TowerBase()//Room13
        {
            Console.WriteLine("");
        }

    }
}

namespace Studio1Project
{
    internal class Program
    {
        private static int roomChoice,heath=100,stamina=100;
        static void Main(string[] args)
        {
            Console.WriteLine("welcome to the game");
            cell();
        }
        static void prisonCell()//room 1 (main room)
        {
            Console.WriteLine("you made it to room 1 \n do you want to go to room 2 or 3");
            roomChoice = Convert.ToInt32(Console.ReadLine());
            if (roomChoice == 2) { 
            Room2();
            }
            else
            {
                sewers();
            }
        }

        static void dungeonHall()
        {
            Console.WriteLine("you win");
            Console.ReadLine();
        }
        static void sewers()//room 3
        { 
            Console.WriteLine("you lose");
            Console.ReadLine();
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

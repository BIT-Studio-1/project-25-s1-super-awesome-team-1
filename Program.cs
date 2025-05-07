namespace Studio1Project
{
    internal class Program
    {
        private static int roomChoice;
        static void Main(string[] args)
        {
            Console.WriteLine("welcome to the game");
            cell();
        }
        static void cell()//room 1 (main room)
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

        static void Room2()
        {
            Console.WriteLine("you win");
            Console.ReadLine();
        }
        static void sewers()//room 3
        { 
            Console.WriteLine("you lose");
            Console.ReadLine();
        }
        static void Room4()
        {
            Console.WriteLine("");
        }
        static void Room5()
        {
            Console.WriteLine("");
        }

    }
}

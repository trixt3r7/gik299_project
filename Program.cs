using System;

namespace gik299_project
{
    class Program
    {

        static Map map = new Map();
        static Player player = new Player();

        static void Main(string[] args)
        {

            Menu menu = new Menu(); //Instans
            menu.GameLogo();

            Console.WriteLine("");

            for (int i = 0; i < 100; i++)
            {
                if (i % 3 == 1)
                {
                    player.VisitedPosition[i] = true;
                }
                Console.WriteLine(player.VisitedPosition[i]);
            }

            Console.WriteLine("");

            map.GenerateMap();

            StartGame();

            /*
            public void Win()
            {

            }

            public void Lose()
            {

            }
            */
        }

        public static void StartGame()
        {

        }
    }
}

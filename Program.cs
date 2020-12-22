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

            Console.WriteLine("rtqwrwqr");

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

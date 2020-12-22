using System;

namespace gik299_project
{
    class Program
    {

        static Map map = new Map();
        static Player player = new Player();
        static Menu menu = new Menu();

        static void Main(string[] args)
        {

            Menu menu = new Menu(); //Instans
            menu.GameLogo();

            Console.WriteLine("");

            menu.MainMenu();

            map.GenerateMap();

            menu.InGameMeny();

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

using System;

namespace gik299_project
{
    class Program
    {

        static Map map = new Map();
        static Player player = new Player();

        static void Main(string[] args)
        {

            Menu menu = new Menu();
            menu.GameLogo();

            player.ShowPlayerStats();

            Console.WriteLine("");

            map.GenerateMap();

            
            StartGame();

            
        }

        public static void StartGame()
        {

        }
    }
}

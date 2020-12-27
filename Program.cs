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
            Console.CursorVisible = false;

            while (true)
            {
                menu.GameLogo();
                menu.MainMenu();
                ConsoleKeyInfo keypress = Console.ReadKey();

                if (keypress.KeyChar == 's' || keypress.KeyChar == 'S')
                {
                    player.SetName();
                    break;
                }
                else if (keypress.KeyChar == 'c' || keypress.KeyChar == 'C')
                {

                }
                else if (keypress.KeyChar == 'q' || keypress.KeyChar == 'Q')
                {
                    Console.Clear();
                    menu.QuitGame();
                    Console.ReadKey();
                    Environment.Exit(1);
                }
                else
                {
                    Console.Clear();
                }
            }

            map.GenerateMap();
            Console.Clear();
            menu.WelcomeText();
            Console.ReadKey();
            Console.Clear();
            menu.StoryText();
            Console.ReadKey();
            Console.Clear();

            Control input = new Control();

            bool activeGame = true;

            string consoleTextField = input.caseSwitch; //Displays text at the top of the menu when you either write a non-existent command or get a command output.

            int[] generatedKeys = map.TotalKeys;

            while (activeGame)
            {

                if (input.caseSwitch == "menu") 
                { 

                }
                else
                {
                    Console.WriteLine(consoleTextField);
                }
                menu.GameLogo();
                map.DrawMap(player);
                if (input.caseSwitch == "menu")
                {
                    menu.InGameMenu();
                }
                else
                {
                    menu.ActionMenu();
                }
                input.PlayerInput(player);
            }


            menu.InGameMenu();

            StartGame();
        }

        public static void StartGame()
        {

        }
    }
}

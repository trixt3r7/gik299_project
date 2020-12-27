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
                Console.WriteLine("\n");
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

            string consoleTextField = input.caseSwitch; //Displays text at the top of the menu when you either write a non-existent command or get a command output.      TEMPORARY

            int[] generatedKeys = map.TotalKeys; //Generates TotalKeys before the game starts.

            while (activeGame) //Game is running.
            {

                //Checks if the player is in the same spot as a key.
                for (int i = 0; i < 10; i++)
                {
                    if (player.PlayerPosition() == generatedKeys[i])
                    {
                        player.Keys++; //Adds a key to the player stats.
                        generatedKeys[i] = -1; //Puts the picked up key outside of the map so it cannot be picked up again.
                    }
                }

                if (player.PlayerPosition() == 10 && player.Keys < 10)
                {
                    Console.WriteLine("You have reached the exit but you do not yet have 10 keys.");
                }
                else if (player.PlayerPosition() == 10 && player.Keys == 10) {
                    Console.WriteLine("You have escaped and won the game. Press any button for credits.");
                    activeGame = false;
                }

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

            while (!activeGame) //Game is over.
            {
                Console.Clear();
                menu.Credits();
                Console.ReadKey();
                Environment.Exit(1);
            }


            menu.InGameMenu();

            StartGame();
        }

        public static void StartGame()
        {

        }
    }
}

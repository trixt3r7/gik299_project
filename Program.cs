using System;

namespace gik299_project
{
    class Program
    {
        static Map map = new Map();
        static Player player = new Player();
        static Enemy enemy = new Enemy();
        static Menu menu = new Menu();
        static Control input = new Control();
        static Highscore highscore = new Highscore();

        static void Main(string[] args)
        {
            menu.WindowSettings();
            StartMenu();
        }

        public static void StartMenu()
        {
            Console.CursorVisible = false;
            while (true)
            {
                menu.GameLogo();
                menu.MainMenu();
                ConsoleKeyInfo keypress = Console.ReadKey(true);

                if (keypress.KeyChar == 's' || keypress.KeyChar == 'S')
                {
                    InGame();
                }
                else if (keypress.KeyChar == 'h' || keypress.KeyChar == 'H')
                {
                    menu.PadTextWL("Show Highscore");
                }
                else if (keypress.KeyChar == 'c' || keypress.KeyChar == 'C')
                {
                    menu.PadTextWL("Show Credits");
                }
                else if (keypress.KeyChar == 'q' || keypress.KeyChar == 'Q')
                {
                    // Exit the game
                    Environment.Exit(0);
                }
                else
                {
                    Console.Clear();
                }
            }
        }

        public static void InGame()
        {
            Console.Clear();
            menu.GameLogo();
            menu.HrLine();
            menu.BootUp();  // Quick bootup for development
            menu.Indent();
            player.ChooseCharacter();

            Console.Clear();
            menu.GameLogo();
            menu.HrLine();
            map.MapSettings();
            map.GenerateMap();
            enemy.GenerateEnemies();
            // Commented out below for faster testing in development
            //menu.StoryText(player);
            Console.CursorVisible = true;

            bool activeGame = true;

            string consoleTextField = input.caseSwitch; // Displays text at the top of the menu when you either write a non-existent command or get a command output.      TEMPORARY

            //List<int> generatedKeys = map.TotalKeys; // Generates TotalKeys before the game starts.
            //List<int> generatedEnemies = enemy.Positions; // Generates TotalEnemies before the game starts.

            string keyRoom = "";

            while (activeGame) //Game is running.
            {
                enemy.CheckForEnemies(player);

                Console.Clear();
                menu.SmallGameLogo();
                menu.HrLine2();
                map.DrawMap(player, enemy);
                menu.HrLine2();
                // Print what room player is in.
                RoomText(keyRoom);
                menu.ActionMenu();

                input.PlayerInput(player);

                // Check if have all keys and are at exit
                if (player.PlayerPosition() == 10 && player.Keys == 10)
                {
                    activeGame = false;
                    menu.Win();
                }

                //Checks if the player is in the same spot as a key.
                keyRoom = map.CheckForKey(player);
            }

            // Onödig while loop med activeGame?
            // Checks bör göras innan om spelaren dör, vinner, stänger ner
            while (!activeGame) //Game is over.
            {
                Console.Clear();
                menu.Credits();
                Console.ReadKey();
                StartMenu();
                //Environment.Exit(1);
            }
        }

        private static void RoomText(string keyRoom)
        {
            if (player.PlayerPrevPosition() == player.PlayerPosition() && player.Steps > 0) // Check for wall
            {
                menu.PadTextW("You reached a wall, you can't go any further in that direction.");
                highscore.CalculateScore();
                highscore.ListPlayers();
            }
            else if (keyRoom.Length == 0 && player.Steps > 0)
            {
                menu.PadTextW($"ROOM {player.PlayerPosition()}: {map.RoomInformation[player.PlayerPosition()]}");
            }
            else if (keyRoom.Length > 0)
            {
                menu.PadTextW(keyRoom);
            }
            else if (player.Steps == 0)
            {
                menu.PadTextW("You found a Weapon.");
            }
            Console.WriteLine();
        }

        // Check health bör göras när man slåss mot fiender.
        //public static void CheckHealth()
        //{
        //    if (player.Health < 1)
        //    {
        //        Lose();
        //    }
        //}
    }
}

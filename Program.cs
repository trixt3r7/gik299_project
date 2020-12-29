using System;
using System.Collections.Generic;

namespace gik299_project
{
    class Program
    {

        static Map map = new Map();
        static Player player = new Player();
        static Enemy enemy = new Enemy();
        static Menu menu = new Menu();
        static Control input = new Control();

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
                //Console.WriteLine("\n");
                menu.GameLogo();
                menu.MainMenu();
                ConsoleKeyInfo keypress = Console.ReadKey(true);

                if (keypress.KeyChar == 's' || keypress.KeyChar == 'S')
                {
                    Console.Clear();
                    menu.GameLogo();
                    menu.HrLine();
                    menu.QuickBootUp();  // Quick bootup for development
                    menu.Indent();
                    player.ChooseCharacter();
                    InGame();
                    //break;
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
            map.MapSettings();
            map.GenerateMap();
            enemy.GenerateEnemies();
            menu.StoryText(player);
            Console.CursorVisible = true;

            bool activeGame = true;

            string consoleTextField = input.caseSwitch; //Displays text at the top of the menu when you either write a non-existent command or get a command output.      TEMPORARY

            List<int> generatedKeys = map.TotalKeys; //Generates TotalKeys before the game starts.
            // List<int> generatedEnemies = enemy.Positions; //Generates TotalEnemies before the game starts.

            string keyRoom = "";

            while (activeGame) //Game is running.
            {
                enemy.CheckForEnemies(player);

                if (player.PlayerPosition() == 10 && player.Keys < 10)
                {
                    menu.PadTextWL("You have reached the exit but you do not yet have 10 keys.");
                }
                else if (player.PlayerPosition() == 10 && player.Keys == 10)
                {
                    menu.PadTextWL("You have escaped and won the game. Press any button for credits.");
                    activeGame = false;
                }

                if (input.caseSwitch == "menu")
                {

                }
                else
                {
                    Console.WriteLine(consoleTextField);
                }

                Console.Clear();
                menu.SmallGameLogo();
                menu.HrLine2();
                map.DrawMap(player, enemy);
                menu.HrLine2();
                // Print what room player is in.
                RoomText(keyRoom);


                if (input.caseSwitch == "menu")
                {
                    menu.InGameMenu();
                }
                else
                {
                    menu.ActionMenu();
                }
                input.PlayerInput(player);

                keyRoom = ""; // Reset if set, before checking for key again
                //Checks if the player is in the same spot as a key.
                for (int i = 0; i < 10; i++)
                {
                    if (player.PlayerPosition() == generatedKeys[i])
                    {
                        Console.Beep(1400, 100);
                        player.Keys++; //Adds a key to the player stats.
                        generatedKeys[i] = 0; //Puts the picked up key outside of the map so it cannot be picked up again.
                        keyRoom = $"ROOM {player.PlayerPosition()}: You found a keycard, you now have: {player.Keys}/{map.KeyAmount}";
                    }
                }
            }

            while (!activeGame) //Game is over.
            {
                Console.Clear();
                menu.Credits();
                Console.ReadKey();
                Environment.Exit(1);
            }


            menu.InGameMenu();

            // StartGame();
        }
        private static void RoomText(string keyRoom)
        {
            if (player.PlayerPrevPosition() == player.PlayerPosition() && player.Steps > 0) // Check for wall
            {
                menu.PadTextW("You reached a wall, you can't go any further in that direction.");
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

        //public static void CheckHealth()
        //{
        //    if (player.Health < 1)
        //    {
        //        Lose();
        //    }
        //}
    }
}

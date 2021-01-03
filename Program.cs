﻿using System;

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
            menu.QuickBootUp();  // Quick bootup for development
            menu.Indent();

            Console.Clear();
            menu.GameLogo();
            menu.HrLine();
            player.Settings();
            map.MapSettings();
            map.GenerateMap();
            enemy.GenerateEnemies();
            player.ChooseCharacter();
            // Commented out below for faster testing in development
            //menu.StoryText(player);
            Console.CursorVisible = true;

            bool activeGame = true;

            string consoleTextField = input.caseSwitch; // Displays text at the top of the menu when you either write a non-existent command or get a command output.      TEMPORARY

            //List<int> generatedKeys = map.TotalKeys; // Generates TotalKeys before the game starts.
            //List<int> generatedEnemies = enemy.Positions; // Generates TotalEnemies before the game starts.

            string keyRoom = "";
            string enemyRoom = "";

            while (activeGame) //Game is running.
            {
                enemyRoom = enemy.CheckForEnemies(player);

                Console.Clear();
                menu.SmallGameLogo();
                menu.HrLine2();
                map.DrawMap(player, enemy);
                menu.HrLine2();
                // Print what room player is in.
                RoomText(keyRoom, enemyRoom);
                menu.ActionMenu();
                input.PlayerInput(player);

                // Check if have all keys and are at exit
                if (player.PlayerPosition() == player.MapSize && player.Keys == map.KeyAmount)
                {
                    activeGame = false;
                    Console.WriteLine(highscore.CalculateScore(player));
                    highscore.ListPlayers();
                    Console.ReadLine();
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

        private static void RoomText(string keyRoom, string enemyRoom)
        {
            if (keyRoom.Length == 0 && enemyRoom.Length == 0 && player.Steps > 0)
            {
                menu.PadTextW($"ROOM {player.PlayerPosition()}: {map.RoomInformation[player.PlayerPosition()]}");
            }
            else if (keyRoom.Length > 0)
            {
                menu.PadTextW(keyRoom);
            }
            else if (enemyRoom.Length > 0)
            {
                menu.PadTextW($"ROOM {player.PlayerPosition()}: {enemyRoom}");
            }
            else if (keyRoom.Length == 0 && player.Steps > 0)
            {
                menu.PadTextW($"ROOM {player.PlayerPosition()}: {map.RoomInformation[player.PlayerPosition()]}");
            }
            else if (keyRoom.Length > 0)
            {
                menu.PadTextW(keyRoom);
            }
            else if (player.PlayerPrevPosition() == player.PlayerPosition() && player.Steps > 0) // Check for wall
            {
                menu.PadTextW("You reached a wall, you can't go any further in that direction.");
            }
            else if (player.Steps == 0)
            {
                menu.PadTextW("You found a Weapon.");
            }
            Console.WriteLine();
        }
    }
}

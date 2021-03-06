﻿using System;

namespace gik299_project
{
    class Program
    {
        static Map map = new Map();
        static Player player = new Player();
        static Enemy enemy = new Enemy();
        static GUI gui = new GUI();
        static Control input = new Control();
        static Highscore highscore = new Highscore();

        static void Main(string[] args)
        {
            gui.WindowSettings();
            highscore.LoadFile();
            StartMenu();
        }

        public static void StartMenu()
        {
            Console.CursorVisible = false;
            while (true)
            {
                gui.GameLogo();
                gui.MainMenu();
                ConsoleKeyInfo keypress = Console.ReadKey(true);

                if (keypress.KeyChar == 's' || keypress.KeyChar == 'S')
                {
                    InGame();
                }
                else if (keypress.KeyChar == 'h' || keypress.KeyChar == 'H')
                {
                    highscore.ShowHighScore();
                    Console.ReadKey();
                    Console.Clear();

                }
                else if (keypress.KeyChar == 'c' || keypress.KeyChar == 'C')
                {
                    gui.Credits();
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
            gui.GameLogo();
            gui.HrLine();

            gui.BootUp();
            input.SetDifficultyLevel(player, enemy, map);
            player.SetName();
            map.GenerateMap();
            gui.StoryText(player, map, enemy);

            Console.CursorVisible = true;

            string keyRoom = "";
            string enemyRoom = "";

            while (true) //Game is running.
            {
                Console.Clear();
                gui.SmallGameLogo();
                gui.HrLine2();
                map.DrawMap(player, enemy);
                gui.HrLine2();
                // Print what room player is in.
                RoomText(keyRoom, enemyRoom);
                gui.ActionMenu();
                input.PlayerInput(player);

                // Check if all keys are obtained and player is at exit.
                if (player.PlayerPosition() == player.MapSize && player.Keys == map.KeyAmount)
                {
                    highscore.AddHighScore(player);
                    gui.Win();
                }

                enemyRoom = enemy.CheckForEnemies(player);

                if (enemyRoom != "flee")
                {
                    //Checks if the player is in the same spot as a key.
                    keyRoom = map.CheckForKey(player);
                }
            }
        }

        private static void RoomText(string keyRoom, string enemyRoom)
        {
            if (keyRoom.Length == 0 && enemyRoom.Length == 0 && player.Steps > 0)
            {
                gui.PadTextW($"ROOM {player.PlayerPosition()}: {map.RoomInformation[player.PlayerPosition()]}");
            }
            else if (keyRoom.Length > 0)
            {
                gui.PadTextW(keyRoom);
            }
            else if (enemyRoom.Length > 0)
            {
                if (enemyRoom == "flee")
                {
                    gui.PadTextW($"ROOM {player.PlayerPosition()}: You successfully flee and rebound to your previous location.");
                }
                else
                {
                    gui.PadTextW($"ROOM {player.PlayerPosition()}: {enemyRoom}");
                }
            }
            else if (keyRoom.Length == 0 && player.Steps > 0)
            {
                gui.PadTextW($"ROOM {player.PlayerPosition()}: {map.RoomInformation[player.PlayerPosition()]}");
            }
            else if (keyRoom.Length > 0)
            {
                gui.PadTextW(keyRoom);
            }
            else if (player.Steps == 0)
            {
                gui.PadTextW("You found a Weapon.");
            }
            Console.WriteLine();
        }
    }
}

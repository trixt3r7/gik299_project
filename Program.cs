using System;

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
                    highscore.LoadFile();

                    player.Name = "Matteh";
                    player.Score = 10000;
                    player.Health = 50;
                    player.MaxHealth = 100;
                    player.Keys = 2;
                    player.Steps = 50;
                    player.MaxSteps = 95;
                    player.MapSize = 10;
                    player.Position = new int[2] { 5, 3 };
                    player.PreviousPosition = new int[2] { 9, 0 };
                    player.VisitedPosition = new bool[100];
                    player.EnemiesKilled = 10;

                    // Need to add name and score to 

                    highscore.AddHighScore(player);
                    highscore.ShowHighScore();
                    //highscore.ListPlayers(player); // Created a LoadFile at 42 instead

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
            gui.QuickBootUp();  // Quick bootup for development
            player.Settings();
            map.MapSettings();
            map.GenerateMap();
            enemy.Settings();
            player.SetName();

            // Commented out below for faster testing in development
            gui.StoryText(player);
            Console.CursorVisible = true;

            string keyRoom = "";
            string enemyRoom = "";

            while (true) //Game is running.
            {
                enemyRoom = enemy.CheckForEnemies(player);

                Console.Clear();
                gui.SmallGameLogo();
                gui.HrLine2();
                map.DrawMap(player, enemy);
                gui.HrLine2();
                // Print what room player is in.
                RoomText(keyRoom, enemyRoom);
                gui.ActionMenu();
                input.PlayerInput(player);

                // Check if have all keys and are at exit
                if (player.PlayerPosition() == player.MapSize && player.Keys == map.KeyAmount)
                {
                    //Console.WriteLine(highscore.CalculateScore(player)); // ------------------------------------------ Commented out

                    Console.ReadLine();
                    gui.Win();
                }
                //Checks if the player is in the same spot as a key.
                keyRoom = map.CheckForKey(player);
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
                gui.PadTextW($"ROOM {player.PlayerPosition()}: {enemyRoom}");
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

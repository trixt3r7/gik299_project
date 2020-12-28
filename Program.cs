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

        static void Main(string[] args)
        {
            menu.WindowSettings();
            StartMenu();


        }
        /*------------------------- MAIN ENDS -------------------------*/

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
                    menu.BootUp();
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
                    // Nödvändig? Kolla upp
                    Console.Clear();
                }
            }
        }

        public static void InGame()
        {
            Console.Clear();
            menu.GameLogo();
            menu.HrLine();
            map.GenerateMap();
            //Console.Clear();
            //menu.WelcomeText();
            //Console.ReadKey();
            //Console.Clear();
            menu.StoryText(player);
            //Console.Clear();
            Console.CursorVisible = true;


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

            // StartGame();
        }

        //public static void StartGame()
        //{
        //    player.ChooseCharacter();
        //}

        //public static void Win()
        //{
        //    Console.WriteLine("You unlock the door and successfully escape.");
        //    Console.WriteLine("YOU WIN!");
        //    Console.WriteLine("Press any key to continue...");
        //}

        //public static void Lose()
        //{
        //    Console.WriteLine($"The {enemy.GetRandomName()} attacks you back and your health reaches 0.");
        //    Console.WriteLine("GAME OVER!");
        //    Console.WriteLine("Press any key to continue...");
        //}

        //public static void CheckHealth()
        //{
        //    if (player.Health < 1)
        //    {
        //        Lose();
        //    }
        //}
    }
}

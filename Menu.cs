using System;
using System.Threading;

namespace gik299_project
{
    class Menu
    {
        public void WindowSettings()
        {
            // Game Area = 8 spaces + 80 chars + 8 spaces
            Console.Title = "Cyber Dungeons";
            Console.SetWindowSize(97, 40);
            //Console.SetBufferSize(89, 40); // Remove scrollbars

            // Console.CursorVisible = false;
        }
        // Color Scheme
        public void PriColor()
        {
            // Primary Color
            Console.ForegroundColor = ConsoleColor.Cyan;
        }
        public void SecColor()
        {
            // Secondary Color
            Console.ForegroundColor = ConsoleColor.Red;
        }
        public void TerColor()
        {
            // Tertiary Color
            Console.ForegroundColor = ConsoleColor.DarkYellow;
        }
        public void ResetColor()
        {
            Console.ResetColor();
        }
        // Indentation for ReadLine's
        public void Indent()
        {
            Console.Write("        ");
        }
        public void PadTextW(string text)
        {

            Console.Write(text.PadLeft(text.Length + 8));
        }
        public void PadTextWL(string text)
        {
            Console.WriteLine(text.PadLeft(text.Length + 8));
        }

        public void CenterText(string textToEnter)
        {
            // Set for character length of 80 (+ 8 empty spaces on left and right)
            Console.SetCursorPosition((96 - textToEnter.Length) / 2, Console.CursorTop);
            Console.WriteLine(textToEnter);
        }
        public void HrLine()
        {
            TerColor(); PadTextW("»»"); ResetColor();
            Console.Write("-----------------------------------------------------------------------------");
            TerColor(); Console.WriteLine("««"); ResetColor();
        }
        public void HrLine2()
        {
            SecColor();
            PadTextWL("---------------------------------------------------------------------------------");
            ResetColor();
        }
        public void GameLogo()
        {
            PriColor(); PadTextWL("                              ______      __");
            SecColor(); PadTextW("■■■■■■■■■■■■■■■■■■■■■■■■■"); PriColor(); Console.Write(@"    / ____/_  __/ /_  ___  _____       "); SecColor(); Console.WriteLine("■■■■■■■■■■■■■■■■■");
            PriColor(); PadTextW("■■■■■■■■■■■■■■■■■■■■■■■"); PriColor(); Console.Write(@"     / /   / / / / __ \/ _ \/ ___/     "); PriColor(); Console.WriteLine("■■■■■■■■■■■■■■■■■■■");
            SecColor(); PadTextW("■■■■■■■■■■■■■■■■■■■■■"); PriColor(); Console.Write(@"      / /___/ /_/ / /_/ /  __/ /       "); SecColor(); Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■");
            PriColor(); PadTextW("■■■■■■■■■■■■■■■"); SecColor(); Console.Write(@"    ____"); PriColor(); Console.WriteLine(@"    \____/\__, /_.___/\___/_/      ■■■■■■■■■■■■■■■■■■■■■■■");
            SecColor(); PadTextW("■■■■■■■■■■■■■"); SecColor(); Console.Write(@"     / __ \__  ____"); PriColor(); Console.Write(@"/____/"); SecColor(); Console.WriteLine(@"__  ___  ____  ____  _____       ■■■■■■■■■■");
            PriColor(); PadTextW("■■■■■■■■■■■"); SecColor(); Console.Write(@"      / / / / / / / __ \/ __ `/ _ \/ __ \/ __ \/ ___/     "); PriColor(); Console.WriteLine("■■■■■■■■■■■■");
            SecColor(); PadTextW("■■■■■■■■■"); SecColor(); Console.Write(@"       / /_/ / /_/ / / / / /_/ /  __/ /_/ / / / (__  )    "); SecColor(); Console.WriteLine("■■■■■■■■■■■■■■");
            PriColor(); PadTextW("■■■■■■■"); SecColor(); Console.Write(@"        /_____/\__,_/_/ /_/\__, /\___/\____/_/ /_/____/   "); PriColor(); Console.WriteLine("■■■■■■■■■■■■■■■■");
            SecColor(); PadTextW("                                 /____/");
            ResetColor();
            Console.WriteLine();
        }
        public void SmallGameLogo()
        {
            PriColor();
            CenterText(@"  _____     __             ___                                 ");
            CenterText(@" / ___/_ __/ /  ___ ____  / _ \__ _____  ___  ___ ___  ___  ___");
            CenterText(@"/ /__/ // / _ \/ -_) __/ / // / // / _ \/ _ `/ -_) _ \/ _ \(_-<");
            CenterText(@"\___/\_, /_.__/\__/_/   /____/\_,_/_//_/\_, /\__/\___/_//_/___/");
            CenterText(@" ≡≡ /___/ ≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡ /___/ ≡≡≡≡≡≡ 2023 ≡≡≡≡≡ ");
            ResetColor();
        }
        public void WelcomeText()
        {
            Player player = new Player();
            Console.WriteLine($"\nGreetings {player.Name}... Other Welcome Text");
        }

        public void StoryText(Player player)
        {
            PriColor(); PadTextW("A.I. GHOST: "); ResetColor(); Console.WriteLine($"Time to wake up {player.Name}.");
            TerColor(); PadTextW($"{player.Name}: "); ResetColor(); Console.WriteLine("What the hell? Feels like I have been run over by a truck.");
            PadTextWL("Where am I?.");
            PriColor(); PadTextW("A.I. GHOST: "); ResetColor(); Console.WriteLine("You have been captured by 'The Nordstroms' and their boss");
            PadTextWL("Taserface wants to take you out himself and is on his way here right");
            PadTextWL("now. They found out that it was you that stole the Military Grade");
            PadTextWL("for their rivalry faction 'Night Runners'.And want to make an");
            PadTextWL("example of you.");
            TerColor(); PadTextW($"{player.Name}: "); ResetColor(); Console.WriteLine("What the...");
            PriColor(); PadTextW("A.I. GHOST: "); ResetColor(); Console.WriteLine("I have repaired you as much as possible. But your neural");
            PadTextWL("transplant is severely damaged and you need to seek out a Neurodoc");
            PadTextWL("ASAP.");
            Console.WriteLine();
            PriColor(); PadTextWL("Press [Enter] key to go to next page..."); ResetColor();
            Console.CursorVisible = false;
            Indent(); Console.ReadLine();

            Console.Clear();
            GameLogo();
            HrLine();

            PriColor(); PadTextW("A.I. GHOST: "); ResetColor(); Console.WriteLine("There are 10 keycards in this base to unlock the door at");
            PadTextWL("the north east exit. I have located a weapon outside this room that");
            PadTextWL("will be useful. List of objectives required to exit the base below:");
            Console.WriteLine();
            TerColor(); PadTextWL("[OBJECTIVES]"); ResetColor();
            PadTextWL("1. Find the 10 keycards located in 10 different rooms. They could be ");
            PadTextWL("located in the same room as enemies.");
            PadTextWL("2. Reach the northeast exit before your health reaches 0 health,");
            PadTextWL("and in under 80 moves before Taserface and the rest of the faction  ");
            PadTextWL("arrives.");
            PadTextWL("3. Watch out for the faction members that are gathered in 10 different");
            PadTextWL("rooms.");

            Console.WriteLine();
            PriColor(); PadTextWL("Press [Enter] to start playing."); ResetColor();
            Indent(); Console.ReadLine();
            Console.CursorVisible = true;
            Console.Clear();
        }

        public void MainMenu()
        {
            HrLine();
            CenterText("Welcome to Cyber Dungeons, a text-based action game.");
            HrLine();

            PriColor();
            CenterText(@"              _                           ");
            CenterText(@"  __ _  ___ _(_)__    __ _  ___ ___  __ __");
            CenterText(@" /  ' \/ _ `/ / _ \  /  ' \/ -_) _ \/ // /");
            CenterText(@"/_/_/_/\_,_/_/_//_/ /_/_/_/\__/_//_/\_,_/ ");
            ResetColor();
            Console.WriteLine("");

            CenterText("[S] Start Game   [H] Highscore   [C] Credits   [Q] Quit Game");
        }

        public void InGameMenu()
        {
            bool active = true;
            while (active)
            {
                Indent(); Console.WriteLine("»»-------------------------------  IN-GAME MENU  ------------------------------««");
                Indent(); Console.WriteLine("                         [resume]   [main menu]   [quit]");
                Indent(); Console.WriteLine("»»-----------------------------------------------------------------------------««");
                string caseSwitch;
                Indent(); Console.Write("Settings: ");
                caseSwitch = Console.ReadLine();
                switch (caseSwitch)
                {
                    case "quit":
                        ConfirmQuit();
                        break;
                    case "resume":
                        Indent(); Console.WriteLine("Resuming game...");
                        active = false;
                        break;
                    case "main menu":
                        ConfirmToMainMenu();
                        break;
                    default:
                        Indent(); Console.WriteLine("Unknown command, please try again.");
                        break;
                }
            }
        }
        public void ConfirmQuit()
        {
            PadTextW("Do you really want to Quit? Type [Y] for Yes or [Any key] to continue.");
            string caseSwitch = Console.ReadLine();
            switch (caseSwitch)
            {
                case "Y":
                case "y":
                    PadTextWL("Thank you for playing. Goodbye.");
                    Environment.Exit(0);
                    break;
                default:
                    PadTextWL("Resuming Game...");
                    break;
            }
        }
        public void ConfirmToMainMenu()
        {
            PadTextW("Do you really want to main menu? Type [Y] for Yes or [Any key] to continue.");
            string caseSwitch = Console.ReadLine();
            switch (caseSwitch)
            {
                case "Y":
                case "y":
                    Console.Clear();
                    // Call for Start Menu
                    Program.StartMenu();
                    break;
                default:
                    PadTextWL("Resuming Game...");
                    break;
            }
        }

        public void ActionMenu()
        {
            PadTextWL("»»-----------------------------------------------------------------------------««");
            PadTextWL("      Movement: [goleft] [goup] [goright] [godown]  |  Settings: [menu] ");
            PadTextWL("»»-----------------------------------------------------------------------------««");
        }

        public void FightMenu()
        {
            PadTextWL("»»-----------------------------------------------------------------------------««");
            PadTextWL("                            Actions: [attack] [flee] ");
            PadTextWL("»»-----------------------------------------------------------------------------««");
        }

        public void Credits()
        {
            Console.WriteLine("'Epic Credits'");
            QuitGame();
        }

        public void QuitGame()
        {
            Console.WriteLine(@"









                           _____                                   __      __              __
                          / ___/___  ___     __  ______  __  __   / /___ _/ /____  _____  / /
                          \__ \/ _ \/ _ \   / / / / __ \/ / / /  / / __ `/ __/ _ \/ ___/ / / 
                         ___/ /  __/  __/  / /_/ / /_/ / /_/ /  / / /_/ / /_/  __/ /    /_/  
                        /____/\___/\___/   \__, /\____/\__,_/  /_/\__,_/\__/\___/_/    (_)   
                                          /____/                                           
                                                                                                ");

        }

        public void Win()
        {
            Console.Clear();
            PriColor();
            SmallGameLogo();
            Console.WriteLine();
            CenterText("You managed to unlock the door and escape.");
            TerColor();
            CenterText(@"__  __               _       ___       __");
            CenterText(@"\ \/ /___  __  __   | |     / (_)___  / /");
            CenterText(@" \  / __ \/ / / /   | | /| / / / __ \/ / ");
            CenterText(@" / / /_/ / /_/ /    | |/ |/ / / / / /_/  ");
            CenterText(@"/_/\____/\__,_/     |__/|__/_/_/ /_(_)   ");
            ResetColor();
            Console.WriteLine();

            CenterText("Press [Enter] key to return to main menu...");
            Console.ReadLine();
            Console.Clear();
            Program.StartMenu();
        }

        public void Lose()
        {
            Console.Clear();
            PriColor();
            SmallGameLogo();
            Console.WriteLine();
            CenterText("Your health reached 0.");
            SecColor();
            CenterText(@"   ______                        ____                  __");
            CenterText(@"  / ____/___ _____ ___  ___     / __ \_   _____  _____/ /");
            CenterText(@" / / __/ __ `/ __ `__ \/ _ \   / / / / | / / _ \/ ___/ / ");
            CenterText(@"/ /_/ / /_/ / / / / / /  __/  / /_/ /| |/ /  __/ /  /_/  ");
            CenterText(@"\____/\__,_/_/ /_/ /_/\___/   \____/ |___/\___/_/  (_)   ");
            ResetColor();
            Console.WriteLine();
            CenterText("Press [Enter] key to return to main menu...");
            Console.ReadLine();
            Console.Clear();
            Program.StartMenu();
        }

        public void LoseBoss()
        {
            Console.Clear();
            PriColor();
            SmallGameLogo();
            Console.WriteLine();
            CenterText("You didn't manage to escape in time.");
            CenterText("Taserface takes you out to the street and executes you in front of an audience.");
            SecColor();
            CenterText(@"   ______                        ____                  __");
            CenterText(@"  / ____/___ _____ ___  ___     / __ \_   _____  _____/ /");
            CenterText(@" / / __/ __ `/ __ `__ \/ _ \   / / / / | / / _ \/ ___/ / ");
            CenterText(@"/ /_/ / /_/ / / / / / /  __/  / /_/ /| |/ /  __/ /  /_/  ");
            CenterText(@"\____/\__,_/_/ /_/ /_/\___/   \____/ |___/\___/_/  (_)   ");
            ResetColor();
            Console.WriteLine();
            CenterText("Press [Enter] key to return to main menu...");
            Console.ReadLine();
            Console.Clear();
            Program.StartMenu();
        }


        // Lägga in flera rader med flashiflash
        // 10% chans till blue screen
        public void BootUp()
        {
            Indent(); Console.Write("BOOTING: ");
            for (int i = 0; i < 20; i++)
            {
                Console.Write($"#");
                Thread.Sleep(25); // Speed of animation
            }
            Console.Write(" [OK]");
            Indent(); Console.WriteLine("");

            string connect = ">";
            Indent(); Console.Write("INITIALIZING CONNECTION: ");
            for (int i = 0; i < 6; i++)
            {
                if (i % 2 == 0)
                {
                    connect = "-";
                }
                else
                {
                    connect = ">";
                }
                for (int j = 0; j < 3; j++)
                {
                    Console.Write($"{connect}");
                    Thread.Sleep(50); // Speed of animation
                }
                Console.Write("\b\b\b");
            }
            Console.WriteLine(">>>  [OK]");
            Indent(); Console.WriteLine("CONNECTION ESTABLISHED");
        }
    }
}

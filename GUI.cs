using System;
using System.Threading;

namespace gik299_project
{
    class GUI
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
        public void PrimaryColor()
        {
            // Primary Color
            Console.ForegroundColor = ConsoleColor.Cyan;
        }
        public void SecondaryColor()
        {
            // Secondary Color
            Console.ForegroundColor = ConsoleColor.Red;
        }
        public void TertiaryColor()
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
        // Adds 8 spaces on the left side.
        public void PadTextW(string text)
        {
            Console.Write(text.PadLeft(text.Length + 8));
        }
        // Adds 8 spaces on the left side.
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
            TertiaryColor(); PadTextW("»»"); ResetColor();
            Console.Write("-----------------------------------------------------------------------------");
            TertiaryColor(); Console.WriteLine("««"); ResetColor();
        }
        public void HrLine2()
        {
            SecondaryColor();
            PadTextWL("---------------------------------------------------------------------------------");
            ResetColor();
        }
        public void GameLogo()
        {
            PrimaryColor(); PadTextWL("                              ______      __");
            SecondaryColor(); PadTextW("■■■■■■■■■■■■■■■■■■■■■■■■■"); PrimaryColor(); Console.Write(@"    / ____/_  __/ /_  ___  _____       "); SecondaryColor(); Console.WriteLine("■■■■■■■■■■■■■■■■■");
            PrimaryColor(); PadTextW("■■■■■■■■■■■■■■■■■■■■■■■"); PrimaryColor(); Console.Write(@"     / /   / / / / __ \/ _ \/ ___/     "); PrimaryColor(); Console.WriteLine("■■■■■■■■■■■■■■■■■■■");
            SecondaryColor(); PadTextW("■■■■■■■■■■■■■■■■■■■■■"); PrimaryColor(); Console.Write(@"      / /___/ /_/ / /_/ /  __/ /       "); SecondaryColor(); Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■");
            PrimaryColor(); PadTextW("■■■■■■■■■■■■■■■"); SecondaryColor(); Console.Write(@"    ____"); PrimaryColor(); Console.WriteLine(@"    \____/\__, /_.___/\___/_/      ■■■■■■■■■■■■■■■■■■■■■■■");
            SecondaryColor(); PadTextW("■■■■■■■■■■■■■"); SecondaryColor(); Console.Write(@"     / __ \__  ____"); PrimaryColor(); Console.Write(@"/____/"); SecondaryColor(); Console.WriteLine(@"__  ___  ____  ____  _____       ■■■■■■■■■■");
            PrimaryColor(); PadTextW("■■■■■■■■■■■"); SecondaryColor(); Console.Write(@"      / / / / / / / __ \/ __ `/ _ \/ __ \/ __ \/ ___/     "); PrimaryColor(); Console.WriteLine("■■■■■■■■■■■■");
            SecondaryColor(); PadTextW("■■■■■■■■■"); SecondaryColor(); Console.Write(@"       / /_/ / /_/ / / / / /_/ /  __/ /_/ / / / (__  )    "); SecondaryColor(); Console.WriteLine("■■■■■■■■■■■■■■");
            PrimaryColor(); PadTextW("■■■■■■■"); SecondaryColor(); Console.Write(@"        /_____/\__,_/_/ /_/\__, /\___/\____/_/ /_/____/   "); PrimaryColor(); Console.WriteLine("■■■■■■■■■■■■■■■■");
            SecondaryColor(); PadTextW("                                 /____/");
            ResetColor();
            Console.WriteLine();
        }
        public void SmallGameLogo()
        {
            PrimaryColor();
            CenterText(@"  _____     __             ___                                 ");
            CenterText(@" / ___/_ __/ /  ___ ____  / _ \__ _____  ___  ___ ___  ___  ___");
            CenterText(@"/ /__/ // / _ \/ -_) __/ / // / // / _ \/ _ `/ -_) _ \/ _ \(_-<");
            CenterText(@"\___/\_, /_.__/\__/_/   /____/\_,_/_//_/\_, /\__/\___/_//_/___/");
            CenterText(@" ≡≡ /___/ ≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡≡ /___/ ≡≡≡≡≡≡ 2021 ≡≡≡≡≡ ");
            ResetColor();
        }

        public void StoryText(Player player)
        {
            PrimaryColor(); PadTextW("A.I. GHOST: "); ResetColor(); Console.WriteLine($"Time to wake up {player.Name}.");
            TertiaryColor(); PadTextW($"{player.Name}: "); ResetColor(); Console.WriteLine("What the hell? Feels like I have been run over by a truck.");
            PadTextWL("Where am I?.");
            PrimaryColor(); PadTextW("A.I. GHOST: "); ResetColor();
            Console.WriteLine("You have been captured by 'The Brunstroms' and their boss Laserface");
            PadTextWL("wants to take you out himself and is on his way here right now. They found ");
            PadTextWL("out that it was you that stole the Military Grade Droid for their");
            PadTextWL("rivalry faction 'Night Runners'. He wants to make an example of you.");
            TertiaryColor(); PadTextW($"{player.Name}: "); ResetColor(); Console.WriteLine("What the...");
            PrimaryColor(); PadTextW("A.I. GHOST: "); ResetColor(); Console.WriteLine("I have repaired you as much as possible. But your neural transplant");
            PadTextWL("is severely damaged and you need to seek out a Neurodoc ASAP.");
            Console.WriteLine();
            PrimaryColor(); PadTextWL("Press any key to go to the next page..."); ResetColor();
            Console.CursorVisible = false;
            Indent(); Console.ReadKey();

            Console.Clear();
            GameLogo();
            HrLine();

            PrimaryColor(); PadTextW("A.I. GHOST: "); ResetColor(); Console.WriteLine("There are 10 keycards in this base to unlock the door at the north");
            PadTextWL("east exit. I have located a weapon outside this room that will be useful.");
            PadTextWL("List of objectives required to exit the base is listed below:");
            Console.WriteLine();
            TertiaryColor(); PadTextWL("[OBJECTIVES]"); ResetColor();
            PadTextWL("1. Find the 10 keycards located in 10 different rooms. They could be located");
            PadTextWL("   in the same room as enemies.");
            PadTextWL("2. Reach the northeast exit before your health reaches 0 health, and in");
            PadTextWL("   under 80 moves before Taserface and the rest of the faction arrives.");
            PadTextWL("3. Watch out for the faction members that are gathered in 10 different rooms.");

            Console.WriteLine();
            PrimaryColor(); PadTextWL("Press any key to start playing."); ResetColor();
            Indent(); Console.ReadKey();
            Console.CursorVisible = true;
            Console.Clear();
        }

        public void MainMenu()
        {
            HrLine();
            CenterText("Welcome to Cyber Dungeons, a text-based action game.");
            CenterText("Created and Published by: Group #1");
            HrLine();

            PrimaryColor();
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
            PadTextW("Do you really want to Quit? Type [Y] for Yes or [Any other key] to cancel quit.");
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
            PadTextW("Confirm return to main menu by typing [Y] for Yes or [Any other key] to cancel.");
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
                    PadTextWL("Returning to main menu canceled.");
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
            Console.Clear();
            Console.WriteLine("'Epic Credits'");
            Console.ReadKey();
            Console.Clear();
            Program.StartMenu();
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

        private void PlayOrQuit()
        {
            CenterText("What do you want to do next?");
            CenterText("[S] Start a new game   [M] Go to Main menu   [Q] Quit Game");
            ConsoleKeyInfo keypress = Console.ReadKey(true);
            // Only reacts to keys listed in below if, else if statements
            if (keypress.KeyChar == 's' || keypress.KeyChar == 'S')
            {
                Program.InGame();
            }
            else if (keypress.KeyChar == 'm' || keypress.KeyChar == 'M')
            {
                Console.Clear();
                Program.StartMenu();
            }
            else if (keypress.KeyChar == 'q' || keypress.KeyChar == 'Q')
            {
                // Exit the application
                Environment.Exit(0);
            }
            else
            {
                Console.Clear();
                SmallGameLogo();
                Console.WriteLine();
                CenterText("You entered invalid input, please try again.");
                Console.WriteLine();
                PlayOrQuit();
            }
        }

        public void Win()
        {
            Console.Clear();
            SmallGameLogo();
            Console.WriteLine();
            CenterText("You managed to unlock the door and escape.");
            TertiaryColor();
            CenterText(@"__  __               _       ___       __");
            CenterText(@"\ \/ /___  __  __   | |     / (_)___  / /");
            CenterText(@" \  / __ \/ / / /   | | /| / / / __ \/ / ");
            CenterText(@" / / /_/ / /_/ /    | |/ |/ / / / / /_/  ");
            CenterText(@"/_/\____/\__,_/     |__/|__/_/_/ /_(_)   ");
            ResetColor();
            Console.WriteLine();
            PlayOrQuit();
        }

        public void Lose()
        {
            Console.Clear();
            SmallGameLogo();
            Console.WriteLine();
            CenterText("Your health reached 0.");
            SecondaryColor();
            CenterText(@"   ______                        ____                  __");
            CenterText(@"  / ____/___ _____ ___  ___     / __ \_   _____  _____/ /");
            CenterText(@" / / __/ __ `/ __ `__ \/ _ \   / / / / | / / _ \/ ___/ / ");
            CenterText(@"/ /_/ / /_/ / / / / / /  __/  / /_/ /| |/ /  __/ /  /_/  ");
            CenterText(@"\____/\__,_/_/ /_/ /_/\___/   \____/ |___/\___/_/  (_)   ");
            ResetColor();
            Console.WriteLine();
            PlayOrQuit();
        }

        public void LoseBoss()
        {
            Console.Clear();
            SmallGameLogo();
            Console.WriteLine();
            CenterText("You didn't manage to escape in time.");
            CenterText("Taserface takes you out to the street and executes you in front of an audience.");
            SecondaryColor();
            CenterText(@"   ______                        ____                  __");
            CenterText(@"  / ____/___ _____ ___  ___     / __ \_   _____  _____/ /");
            CenterText(@" / / __/ __ `/ __ `__ \/ _ \   / / / / | / / _ \/ ___/ / ");
            CenterText(@"/ /_/ / /_/ / / / / / /  __/  / /_/ /| |/ /  __/ /  /_/  ");
            CenterText(@"\____/\__,_/_/ /_/ /_/\___/   \____/ |___/\___/_/  (_)   ");
            ResetColor();
            Console.WriteLine();
            PlayOrQuit();
        }


        // Lägga in flera rader med flashiflash
        // 10% chans till blue screen
        public void QuickBootUp()
        {
            Indent(); Console.Write("BOOTING: ");
            for (int i = 0; i < 10; i++)
            {
                Console.Write($"#");
                // Yield the rest of the time slice.
                Thread.Sleep(25);
            }
            PrimaryColor(); Console.WriteLine("    [OK]"); ResetColor();
            PadTextWL("CONNECTION ESTABLISHED");
        }
        public void BootUp()
        {
            Indent(); Console.Write("BOOTING: ");
            for (int i = 0; i < 20; i++)
            {
                Console.Write($"#");
                Thread.Sleep(25); // Speed of animation
            }
            PrimaryColor(); Console.Write("    [OK]"); ResetColor();
            Indent(); Console.WriteLine("");

            Indent(); Console.Write("NEURAL LINK: ");
            for (int i = 0; i < 16; i++)
            {
                if (i > 3 && i < 8 || i > 10 && i < 12)
                {
                    Console.Write($"X");
                    Thread.Sleep(300); // Speed of animation
                }
                else
                {
                    Console.Write($"#");
                    Thread.Sleep(50); // Speed of animation
                }
            }
            SecondaryColor(); Console.Write("    [DAMAGED]"); ResetColor();

            //MEMORY CHECK
            Indent(); Console.WriteLine("");
            Indent(); Console.Write("MEMORY CHECK:    TB");
            Console.CursorVisible = false;
            for (int i = 0; i < 33; i++)
            {
                Console.SetCursorPosition(22, Console.CursorTop);
                Console.Write(i);
                Thread.Sleep(50);
            }
            Console.Write(" TB");
            PrimaryColor(); Console.WriteLine("              [OK]"); ResetColor();
            Console.CursorVisible = true;
            string connect = ">";
            Indent(); Console.Write("INITIALIZING UPLINK: ");
            for (int i = 0; i < 4; i++)
            {
                if (i % 2 == 0)
                {
                    connect = "-";
                }
                else
                {
                    connect = ">";
                }
                for (int j = 0; j < 8; j++)
                {
                    Console.Write($"{connect}");
                    // Yield the rest of the time slice.
                    Thread.Sleep(50);
                }
                Console.Write("\b\b\b\b\b\b\b\b");
            }
            Console.Write(">>>>>>>>");
            PrimaryColor(); Console.WriteLine("    [OK]"); ResetColor();
            Indent(); Console.WriteLine("CONNECTION ESTABLISHED");
        }
    }
}

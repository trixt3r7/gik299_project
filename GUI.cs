using System;
using System.Threading;

namespace gik299_project
{
    class GUI
    {
        public void WindowSettings()
        {
            Console.Title = "Cyber Dungeons";
            // Game Area = 8 spaces + 80 chars + 8 spaces
            Console.SetWindowSize(98, 40);
        }

        // Color Scheme: Primary, Secondary, Tertiary, 3 methods
        public void PrimaryColor()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
        }

        public void SecondaryColor()
        {
            Console.ForegroundColor = ConsoleColor.Red;
        }

        public void TertiaryColor()
        {
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

        // Used in methods with secondary parameter for color
        public void SetColor(string color)
        {
            switch (color)
            {
                case "P":
                    PrimaryColor();
                    break;
                case "S":
                    SecondaryColor();
                    break;
                case "T":
                    TertiaryColor();
                    break;
                default:
                    Console.ResetColor();
                    break;
            }
        }

        public void PadTextW(string text, string color)
        {
            SetColor(color);
            Console.Write(text.PadLeft(text.Length + 8));
        }

        public void PadTextWL(string text, string color)
        {
            SetColor(color);
            Console.WriteLine(text.PadLeft(text.Length + 8));
        }

        public void Write(string text, string color)
        {
            SetColor(color);
            Console.Write(text);
        }

        public void WriteLine(string text, string color)
        {
            SetColor(color);
            Console.WriteLine(text);
        }

        public void CenterText(string textToEnter)
        {
            // Set for character length of 80 (+ 8 empty spaces on left and right)
            Console.SetCursorPosition((96 - textToEnter.Length) / 2, Console.CursorTop);
            Console.WriteLine(textToEnter);
        }

        public void HrLine()
        {
            PadTextW("»»", "T");
            Write("-----------------------------------------------------------------------------", "");
            WriteLine("««", "T");
            ResetColor();
        }

        public void HrLine2()
        {
            SecondaryColor();
            PadTextWL("---------------------------------------------------------------------------------");
            ResetColor();
        }

        public void GameLogo()
        {
            PadTextW("                         "); WriteLine("     ______      __", "P");
            PadTextW("■■■■■■■■■■■■■■■■■■■■■■■■■", "S"); Write(@"    / ____/_  __/ /_  ___  _____       ", "P"); WriteLine("■■■■■■■■■■■■■■■■■", "S");
            PadTextW("■■■■■■■■■■■■■■■■■■■■■■■", "P"); Write(@"     / /   / / / / __ \/ _ \/ ___/     ", "P"); WriteLine("■■■■■■■■■■■■■■■■■■■", "P");
            PadTextW("■■■■■■■■■■■■■■■■■■■■■", "S"); Write(@"      / /___/ /_/ / /_/ /  __/ /       ", "P"); WriteLine("■■■■■■■■■■■■■■■■■■■■■", "S");
            PadTextW("■■■■■■■■■■■■■■■", "P"); Write(@"    ____", "S"); WriteLine(@"    \____/\__, /_.___/\___/_/      ■■■■■■■■■■■■■■■■■■■■■■■", "P");
            PadTextW("■■■■■■■■■■■■■", "S"); Write(@"     / __ \__  ____", "S"); Write(@"/____/", "P"); WriteLine(@"__  ___  ____  ____  _____       ■■■■■■■■■■", "S");
            PadTextW("■■■■■■■■■■■", "P"); Write(@"      / / / / / / / __ \/ __ `/ _ \/ __ \/ __ \/ ___/     ", "S"); WriteLine("■■■■■■■■■■■■", "P");
            PadTextW("■■■■■■■■■", "S"); Write(@"       / /_/ / /_/ / / / / /_/ /  __/ /_/ / / / (__  )    ", "S"); WriteLine("■■■■■■■■■■■■■■", "S");
            PadTextW("■■■■■■■", "P"); Write(@"        /_____/\__,_/_/ /_/\__, /\___/\____/_/ /_/____/   ", "S"); WriteLine("■■■■■■■■■■■■■■■■", "P");
            PadTextW("                                 /____/", "S");
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

        public void StoryText(Player player, Map map, Enemy enemy)
        {
            Console.Clear();
            GameLogo();
            HrLine();
            PadTextW("A.I. GHOST: ", "P");
            WriteLine($"Time to wake up {player.Name}.", "");
            PadTextW($"{player.Name}: ", "T");
            WriteLine("What the hell? Feels like I have been run over by a truck.", "");
            PadTextWL("Where am I?.");
            PadTextW("A.I. GHOST: ", "P");
            WriteLine("You have been captured by 'The Brunstroms' and their boss Laserface", "");
            PadTextWL("wants to take you out himself and is on his way here right now. They found ");
            PadTextWL("out that it was you that stole the Military Grade Droid for their");
            PadTextWL("rivalry faction 'Night Runners'. He wants to make an example of you.");
            PadTextW($"{player.Name}: ", "T");
            WriteLine("What the...", "");
            PadTextW("A.I. GHOST: ", "P");
            WriteLine("I have repaired you as much as possible. But your neural transplant", "");
            PadTextWL("is severely damaged and you need to seek out a Neurodoc ASAP.");
            Console.WriteLine();
            PadTextWL("Press any key to go to the next page...", "P");
            ResetColor();
            Console.CursorVisible = false;
            Indent();
            Console.ReadKey();

            Console.Clear();
            GameLogo();
            HrLine();

            PadTextW("A.I. GHOST: ", "P");
            WriteLine($"There are {map.KeyAmount} keycards in this base to unlock the door at the north", "");
            PadTextWL("east exit. I have located a weapon outside this room that will be useful.");
            PadTextWL("List of objectives required to exit the base is listed below:");
            Console.WriteLine();
            PadTextWL("[OBJECTIVES]", "T");
            PadTextWL($"1. Find the {map.KeyAmount} keycards located in {map.KeyAmount} different rooms. They could be located", "");
            PadTextWL("   in the same room as enemies.");
            PadTextWL("2. Reach the northeast exit before your health reaches 0 health, and in");
            PadTextWL($"   under {player.MaxSteps} moves before Taserface and the rest of the faction arrives.");
            PadTextWL($"3. Watch out for the faction members that are gathered in {enemy.Count} different rooms.");

            Console.WriteLine();
            PadTextWL("Press any key to start playing.", "P");
            ResetColor();
            Indent();
            Console.ReadKey();
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

        public void HighScore()
        {
            Console.Clear();
            GameLogo();
            HrLine();
            CenterText("Here you can view your local scoreboard.");
            HrLine();
            PrimaryColor();
            CenterText(@"   __   _      __                         ");
            CenterText(@"  / /  (_)__ _/ /    ___ _______  _______ ");
            CenterText(@" / _ \/ / _ `/ _ \  (_-</ __/ _ \/ __/ -_)");
            CenterText(@"/_//_/_/\_, /_//_/ /___/\__/\___/_/  \__/ ");
            CenterText(@"       /___/                              ");
            Console.WriteLine();
        }
        public void InGameMenu()
        {
            bool active = true;
            while (active)
            {
                PadTextWL("»»-------------------------------  IN-GAME MENU  ------------------------------««");
                PadTextWL("                         [resume]   [main menu]   [quit]");
                PadTextWL("»»-----------------------------------------------------------------------------««");
                string caseSwitch;
                PadTextW("Settings: ");
                caseSwitch = Console.ReadLine();
                switch (caseSwitch)
                {
                    case "quit":
                        ConfirmQuit();
                        break;
                    case "resume":
                        PadTextWL("Resuming game...");
                        active = false;
                        break;
                    case "main menu":
                        ConfirmToMainMenu();
                        break;
                    default:
                        PadTextWL("Unknown command, please try again.");
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
            PadTextWL("  Movement:  [left]/[a]  [up]/[w]  [right]/[d]  [down]/[s]  |  Settings: [menu]  ");
            PadTextWL("»»-----------------------------------------------------------------------------««");
            //PadTextWL("»»-----------------------------------------------------------------------------««");
            //PadTextWL("      Movement: [goleft] [goup] [goright] [godown]  |  Settings: [menu] ");
            //PadTextWL("»»-----------------------------------------------------------------------------««");
        }

        public void FightMenu()
        {
            PadTextWL("»»-----------------------------------------------------------------------------««");
            PadTextWL("                        Actions: [attack]/[a]  [flee]/[f]                        ");
            PadTextWL("»»-----------------------------------------------------------------------------««");
        }

        public void Credits()
        {
            Console.Clear();
            GameLogo();
            HrLine();
            CenterText("");
            CenterText("");
            PrimaryColor();
            CenterText("Programmers");
            ResetColor();
            CenterText("Mattias Hedlund");
            CenterText("Linus Nordström");
            CenterText("Philip Sinnott");
            CenterText("");
            CenterText("");
            CenterText("");
            SecondaryColor();
            CenterText("Graphics Designers");
            ResetColor();
            CenterText("UI and UX Designer | Mattias Hedlund");
            CenterText("Map Designer | Linus Nordström");
            CenterText("");
            CenterText("");
            CenterText("");
            PrimaryColor();
            CenterText("Narrative Designers");
            ResetColor();
            CenterText("Lead Story Designer | Mattias Hedlund");
            CenterText("Room Designer | Philip Sinnott");
            CenterText("Story Designer | Linus Nordström");
            CenterText("");
            CenterText("");
            CenterText("");
            TertiaryColor();
            CenterText("Special Thanks");
            ResetColor();
            CenterText("Educator | Thomas Brunström");
            CenterText("");
            CenterText("");
            CenterText("");
            CenterText("Press any key to return to main menu.");
            Console.ReadKey();
            Console.Clear();
            Program.StartMenu();
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

        public void QuickBootUp()
        {
            Indent(); Console.Write("BOOTING: ");
            for (int i = 0; i < 10; i++)
            {
                Console.Write($"#");
                // Yield the rest of the time slice.
                Thread.Sleep(25);
            }
            PadTextWL("    [OK]", "P");
            PadTextWL("CONNECTION ESTABLISHED", "");
        }
        public void BootUp()
        {
            PadTextW("BOOTING: ");
            for (int i = 0; i < 20; i++)
            {
                Console.Write($"#");
                Thread.Sleep(20); // Speed of animation
            }
            Write("    [OK]", "P");
            ResetColor();

            // Easter egg: Blue Screen Of Dead
            Random random = new Random();
            int bsod = random.Next(1, 100);
            if (bsod < 50)
            {
                BSOD();
                GameLogo();
                HrLine();
                PadTextW("BOOTING: ");
                for (int i = 0; i < 20; i++)
                {
                    Console.Write($"#");
                    Thread.Sleep(25); // Speed of animation
                }
                Write("    [OK]", "P");
                ResetColor();
            }
            Console.WriteLine();
            PadTextW("OPERATING SYSTEM: ");
            Thread.Sleep(200);
            Console.Write("L");
            Thread.Sleep(200);
            Console.Write("I");
            Thread.Sleep(200);
            Console.Write("N");
            Thread.Sleep(200);
            Console.Write("U");
            Thread.Sleep(200);
            Console.Write("S");
            Thread.Sleep(200);
            Console.Write("\b ");
            Console.Write("\b");
            Thread.Sleep(200);
            Console.Write("X");
            Thread.Sleep(200);
            WriteLine("          [OK]", "P");
            ResetColor();
            PadTextW("NEURAL LINK: ");
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
            Write("    [DAMAGED]", "S");
            ResetColor();

            //MEMORY CHECK
            PadTextWL("");
            PadTextW("MEMORY CHECK:    TB");
            Console.CursorVisible = false;
            for (int i = 0; i < 33; i++)
            {
                Console.SetCursorPosition(22, Console.CursorTop);
                Console.Write(i);
                Thread.Sleep(50);
            }
            Console.Write(" TB");
            WriteLine("              [OK]", "P");
            ResetColor();
            Console.CursorVisible = true;
            string connect = ">";
            PadTextW("INITIALIZING UPLINK: ");
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
                    Thread.Sleep(40);
                }
                Console.Write("\b\b\b\b\b\b\b\b");
            }
            Console.Write(">>>>>>>>");
            WriteLine("    [OK]", "P");
            ResetColor();
            PadTextWL("CONNECTION ESTABLISHED");
        }

        public void BSOD()
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetWindowSize(96, 38);
            Console.WriteLine(@"                                                                                                 
                                                                                                 
                                                                                                 
                                                                                                 
                                                                                                 
                                                                                                 
                                                                                                 
                                                                                                 
                                                                                                 
                                                                                                 
                                                                                                 
                                                                                                 
                                                                                                 
                                                                                                 
                                                                                                 
                                          SYSTEM ERROR                                           
                                                                                                 
              A fatal exeption 0E76534801 has occured at 0026:00001D2. The current               
              application will be terminated.                                                    
                                                                                                 
              * Press any key to terminate the current application.                              
              * Press CTRL+ALT+DEL again to restart your computer. You will                      
                lose any unsaved information in all applications.                                
                                                                                                 
                                 Press any key to continue                                       
                                                                                                 
                                                                                                 
                                                                                                 
                                                                                                 
                                                                                                 
                                                                                                 
                                                                                                 
                                                                                                 
                                                                                                 
                                                                                                 
                                                                                                 
                                                                                                 
                                                                                                 
                                                                                                 
                                                                                                 
                                                                                                 
                                                                                                 
                                                                                                 
                                                                                                 
                                                                                                 
                                                                                                 
                                                                                                                                      
");
            Console.ReadKey();
            ResetColor();
            Console.SetWindowSize(98, 40);
            Console.Clear();
        }
    }
}

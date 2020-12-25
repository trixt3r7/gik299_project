using System;
using System.Threading;

namespace gik299_project
{
    class Menu
    {
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
        public void Indent()
        {
            Console.Write("                    ");
        }

        public void GameLogo()
        {
            Indent(); PriColor(); Console.WriteLine("                         ______      __");
            Indent(); SecColor(); Console.Write("■■■■■■■■■■■■■■■■■■■■■"); PriColor(); Console.Write(@"   / ____/_  __/ /_  ___  _____       "); SecColor(); Console.WriteLine("■■■■■■■■■■■■■■");
            Indent(); PriColor(); Console.Write("■■■■■■■■■■■■■■■■■■■"); PriColor(); Console.Write(@"    / /   / / / / __ \/ _ \/ ___/     "); PriColor(); Console.WriteLine("■■■■■■■■■■■■■■■■");
            Indent(); SecColor(); Console.Write("■■■■■■■■■■■■■■■■■"); PriColor(); Console.Write(@"     / /___/ /_/ / /_/ /  __/ /      "); SecColor(); Console.WriteLine("■■■■■■■■■■■■■■■■■■■");
            Indent(); PriColor(); Console.Write("■■■■■■■■■■■■"); SecColor(); Console.Write(@"  ____"); PriColor(); Console.WriteLine(@"    \____/\__, /_.___/\___/_/     ■■■■■■■■■■■■■■■■■■■■■");
            Indent(); SecColor(); Console.Write("■■■■■■■■■■"); SecColor(); Console.Write(@"   / __ \__  ____"); PriColor(); Console.Write(@"/____/");
            SecColor(); Console.WriteLine(@"__  ___  ____  ____  _____      ■■■■■■■■");
            Indent(); PriColor(); Console.Write("■■■■■■■■"); SecColor(); Console.Write(@"    / / / / / / / __ \/ __ `/ _ \/ __ \/ __ \/ ___/     "); PriColor(); Console.WriteLine("■■■■■■■■■");
            Indent(); SecColor(); Console.Write("■■■■■■"); SecColor(); Console.Write(@"     / /_/ / /_/ / / / / /_/ /  __/ /_/ / / / (__  )    "); SecColor(); Console.WriteLine("■■■■■■■■■■■");
            Indent(); PriColor(); Console.Write("■■■■"); SecColor(); Console.Write(@"      /_____/\__,_/_/ /_/\__, /\___/\____/_/ /_/____/  "); PriColor(); Console.WriteLine("■■■■■■■■■■■■■■");
            Indent(); SecColor(); Console.WriteLine("                            /____/");
            ResetColor();
        }
        public void WelcomeText()
        {
            Player player = new Player();
            Console.WriteLine($"\nGreetings {player.Name}... Other Welcome Text");
        }

        public void StoryText(Player player)
        {
            GameLogo();
            Indent(); PriColor(); Console.Write("A.I. GHOST: "); ResetColor(); Console.WriteLine("Time to wake up {0}.", player.Name);
            Indent(); TerColor(); Console.Write("{0}: ", player.Name); ResetColor(); Console.WriteLine("What the hell? Feels like I have been run over by a truck.");
            Indent(); Console.WriteLine("Where am I?.");
            Indent(); PriColor(); Console.Write("A.I. GHOST: "); ResetColor(); Console.WriteLine("You have been captured by 'The Nordstroms' and their boss");
            Indent(); Console.WriteLine("Taserface wants to take you out himself and is on his way here right");
            Indent(); Console.WriteLine("now. They found out that it was you that stole the Military Grade");
            Indent(); Console.WriteLine("for their rivalry faction 'Night Runners'.And want to make an");
            Indent(); Console.WriteLine("example of you.");
            Indent(); TerColor(); Console.Write("{0}: ", player.Name); ResetColor(); Console.WriteLine("What the...");
            Indent(); PriColor(); Console.Write("A.I. GHOST: "); ResetColor(); Console.WriteLine("I have repaired you as much as possible. But your neural");
            Indent(); Console.WriteLine("transplant is severely damaged and you need to seek out a Neurodoc");
            Indent(); Console.WriteLine("ASAP.");
            Console.WriteLine();
            Indent(); PriColor(); Console.WriteLine("Press [Enter] key to go to next page..."); ResetColor();
            Console.CursorVisible = false;
            Indent(); Console.ReadLine();

            Console.Clear();
            GameLogo();
            Indent(); PriColor(); Console.Write("A.I. GHOST: "); ResetColor(); Console.WriteLine("There are 10 keycards in this base to unlock the door at");
            Indent(); Console.WriteLine("the north east exit. I have located a weapon outside this room that");
            Indent(); Console.WriteLine("will be useful. List of objectives required to exit the base below:");
            Console.WriteLine();
            Indent(); TerColor(); Console.WriteLine("[OBJECTIVES]"); ResetColor();
            Indent(); Console.WriteLine("1. Find the 10 keycards located in 10 different rooms. They could be ");
            Indent(); Console.WriteLine("located in the same room as enemies.");
            Indent(); Console.WriteLine("2. Reach the northeast exit before your health reaches 0 health,");
            Indent(); Console.WriteLine("and in under 80 moves before Taserface and the rest of the faction  ");
            Indent(); Console.WriteLine("arrives.");
            Indent(); Console.WriteLine("3. Watch out for the faction members that are gathered in 10 different");
            Indent(); Console.WriteLine("rooms.");

            Console.WriteLine();
            Indent(); PriColor(); Console.WriteLine("Press [Enter] to start playing."); ResetColor();
            Indent(); Console.ReadLine();
            Console.CursorVisible = true;
            Console.Clear();
        }

        public void MainMenu()
        {
            Console.WriteLine("\n\n\n\n");
            Console.WriteLine("                            ╔══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("                            ║      __  ______    _____   __     __  __________   ____  __  ║");
            Console.WriteLine("                            ║     /  |/  /   |  /  _/ | / /    /  |/  / ____/ | / / / / /  ║");
            Console.WriteLine("                            ║    / /|_/ / /| |  / //  |/ /    / /|_/ / __/ /  |/ / / / /   ║");
            Console.WriteLine("                            ║   / /  / / ___ |_/ // /|  /    / /  / / /___/ /|  / /_/ /    ║");
            Console.WriteLine("                            ║  /_/  /_/_/  |_/___/_/ |_/    /_/  /_/_____/_/ |_/\\____/     ║");
            Console.WriteLine("                    ╔═══════╣                                                              ╠═══════╗");
            Console.WriteLine("                    ║       ╚══════════════════════════════════════════════════════════════╝       ║");
            Console.WriteLine("                    ║                                                                              ║");
            Console.WriteLine("                    ║            [S] START GAME        [C] CREDITS        [Q] QUIT GAME            ║");
            Console.WriteLine("                    ║                                                                              ║");
            Console.WriteLine("                    ╚══════════════════════════════════════════════════════════════════════════════╝");

        }

        public void Settings()
        {

        }

        public void InGameMenu()
        {
            Console.WriteLine("                            ╔══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("                    ╔═══════╣                         IN-GAME MENU                         ╠═══════╗");
            Console.WriteLine("                    ║       ╚══════════════════════════════════════════════════════════════╝       ║");
            Console.WriteLine("                    ║               [STATS]             [RESUME]              [QUIT]               ║");
            Console.WriteLine("                    ╚══════════════════════════════════════════════════════════════════════════════╝");
        }

        public void ActionMenu()
        {
            Console.WriteLine("                            ╔══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("                    ╔═══════╣                         ACTION MENU                          ╠═══════╗");
            Console.WriteLine("                    ║       ╚══════════════════════════════════════════════════════════════╝       ║");
            Console.WriteLine("                    ║                                                                              ║");
            Console.WriteLine("                    ║        MOVEMENT:     [GOUP]      [GORIGHT]     [GODOWN]     [GORIGHT]        ║");
            Console.WriteLine("                    ║                                                                              ║");
            Console.WriteLine("                    ║        OTHER OPTIONS:   [ATTACK]    [FLEE]          SETTINGS:  [MENU]        ║");
            Console.WriteLine("                    ║                                                                              ║");
            Console.WriteLine("                    ╚══════════════════════════════════════════════════════════════════════════════╝");
        }

        public void FightMenu()
        {
            Console.WriteLine("                            ╔══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("                    ╔═══════╣                          FIGHT MENU                          ╠═══════╗");
            Console.WriteLine("                    ║       ╚══════════════════════════════════════════════════════════════╝       ║");
            Console.WriteLine("                    ║               [ATTACK]             [FLEE]               [MENU]               ║");
            Console.WriteLine("                    ╚══════════════════════════════════════════════════════════════════════════════╝");
        }

        public void Credits()
        {

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

        public void InGameMeny()
        {

        }

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

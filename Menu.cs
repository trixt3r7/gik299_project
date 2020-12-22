using System;

namespace gik299_project
{
    class Menu
    {

        public void GameLogo()
        {
            Console.WriteLine("                        ______      __              ____                                         ");
            Console.WriteLine("                       / ____/_  __/ /_  ___  _____/ __ \\__  ______  ____ ____  ____  ____  _____");
            Console.WriteLine("                      / /   / / / / __ \\/ _ \\/ ___/ / / / / / / __ \\/ __ `/ _ \\/ __ \\/ __ \\/ ___/");
            Console.WriteLine("                     / /___/ /_/ / /_/ /  __/ /  / /_/ / /_/ / / / / /_/ /  __/ /_/ / / / (__  ) ");
            Console.WriteLine("                     \\____/\\__, /_.___/\\___/_/  /_____/\\__,_/_/ /_/\\__, /\\___/\\____/_/ /_/____/  ");
            Console.WriteLine("                          /____/                                  /____/                  ");
        }
        public void WelcomeText()
        {
            Console.WriteLine("\nSome Welcome Text Hehe...");
        }

        public void StoryText()
        {
            Console.WriteLine("\n*A very epic story*");
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
    }
}

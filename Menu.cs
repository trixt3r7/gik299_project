using System;

namespace gik299_project
{
    class Menu
    {

        public void GameLogo()
        {
            Console.WriteLine(@"
                 ______      __                    
                / ____/_  __/ /_  ___  _____       
               / /   / / / / __ \/ _ \/ ___/       
              / /___/ /_/ / /_/ /  __/ /           
              \____/\__, /_.___/\___/_/     
      ____         /____/
     / __ \__  ______  ____  ___  ____  ____  _____
    / / / / / / / __ \/ __ `/ _ \/ __ \/ __ \/ ___/
   / /_/ / /_/ / / / / /_/ /  __/ /_/ / / / (__  ) 
  /_____/\__,_/_/ /_/\__, /\___/\____/_/ /_/____/  
                    /____/");
        }

        public void WelcomeText()
        {

        }

        public void StoryText()
        {

        }

        public void MainMenu()
        {
            Console.WriteLine();
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

        public void InGameMeny()
        {
            Console.WriteLine("                            ╔══════════════════════════════════════════════════════════════╗");
            Console.WriteLine("                    ╔═══════╣                         IN-GAME MENU                         ╠═══════╗");
            Console.WriteLine("                    ║       ╚══════════════════════════════════════════════════════════════╝       ║");
            Console.WriteLine("                    ║               [STATS]             [RESUME]              [QUIT]               ║");
            Console.WriteLine("                    ╚══════════════════════════════════════════════════════════════════════════════╝");
        }

        public void Credits()
        {

        }
    }
}

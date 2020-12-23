using System;

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

        public void GameLogo()
        {
            PriColor(); Console.WriteLine("                         ______      __");
            SecColor(); Console.Write("■■■■■■■■■■■■■■■■■■■■■"); PriColor(); Console.Write(@"   / ____/_  __/ /_  ___  _____       "); SecColor(); Console.WriteLine("■■■■■■■■■■■■■■");
            PriColor(); Console.Write("■■■■■■■■■■■■■■■■■■■"); PriColor(); Console.Write(@"    / /   / / / / __ \/ _ \/ ___/     "); PriColor(); Console.WriteLine("■■■■■■■■■■■■■■■■");
            SecColor(); Console.Write("■■■■■■■■■■■■■■■■■"); PriColor(); Console.Write(@"     / /___/ /_/ / /_/ /  __/ /      "); SecColor(); Console.WriteLine("■■■■■■■■■■■■■■■■■■■");
            PriColor(); Console.Write("■■■■■■■■■■■■"); SecColor(); Console.Write(@"  ____"); PriColor(); Console.WriteLine(@"    \____/\__, /_.___/\___/_/     ■■■■■■■■■■■■■■■■■■■■■");
            SecColor(); Console.Write("■■■■■■■■■■"); SecColor(); Console.Write(@"   / __ \__  ____"); PriColor(); Console.Write(@"/____/");
            SecColor(); Console.WriteLine(@"__  ___  ____  ____  _____      ■■■■■■■■");
            PriColor(); Console.Write("■■■■■■■■"); SecColor(); Console.Write(@"    / / / / / / / __ \/ __ `/ _ \/ __ \/ __ \/ ___/     "); PriColor(); Console.WriteLine("■■■■■■■■■");
            SecColor(); Console.Write("■■■■■■"); SecColor(); Console.Write(@"     / /_/ / /_/ / / / / /_/ /  __/ /_/ / / / (__  )    "); SecColor(); Console.WriteLine("■■■■■■■■■■■");
            PriColor(); Console.Write("■■■■"); SecColor(); Console.Write(@"      /_____/\__,_/_/ /_/\__, /\___/\____/_/ /_/____/  "); PriColor(); Console.WriteLine("■■■■■■■■■■■■■■");
            SecColor(); Console.WriteLine("                            /____/");
            ResetColor();
        }
        public void WelcomeText()
        {

        }

        public void StoryText()
        {

        }

        public void MainMenu()
        {

        }

        public void Settings()
        {

        }

        public void InGameMeny()
        {

        }

        public void Credits()
        {

        }
    }
}

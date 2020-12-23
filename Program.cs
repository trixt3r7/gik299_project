using System;

namespace gik299_project
{
    class Program
    {

        static Map map = new Map();
        static Player player = new Player();
        static Enemy enemy = new Enemy();

        static void Main(string[] args)
        {

            Menu menu = new Menu();
            menu.GameLogo();

            player.ShowPlayerStats();

            player.Attack();

            map.GenerateMap();

            
            StartGame();

            
        }

        public static void StartGame()
        {
            player.ChooseCharacter();
        }

        public static void Win()
        {
            Console.WriteLine("You unlock the door and successfully escape.");
            Console.WriteLine("YOU WIN!");
            Console.WriteLine("Press any key to continue...");
        }

        public static void Lose()
        {
            Console.WriteLine($"The {enemy.GetRandomName()} attacks you back and your health reaches 0.");
            Console.WriteLine("GAME OVER!");
            Console.WriteLine("Press any key to continue...");
        }

        public static void CheckHealth()
        {
            if (player.Health < 1)
            {
                Lose();
            }
        }
    }
}

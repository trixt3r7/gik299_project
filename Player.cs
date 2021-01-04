using System;

namespace gik299_project
{
    class Player
    {
        // Instansiering av klasser
        Enemy enemy = new Enemy();
        GUI gui = new GUI();

        public string Name;
        public int Health;
        public int MaxHealth;
        public int Keys;
        public int Steps;
        public int MaxSteps;
        public int MapSize;
        public int[] Position;
        public int[] PreviousPosition;
        public bool[] VisitedPosition;
        public int EnemiesKilled;

        public void Settings(ConsoleKeyInfo difficulty)
        {
            Name = "";
            Keys = 0;
            Steps = 0;
            Position = new int[2] { 9, 0 };
            PreviousPosition = new int[2] { 9, 0 };
            EnemiesKilled = 0;
            
            // EASY
            if (difficulty.KeyChar == '0')
            {
                Health = 100;
                MaxHealth = 100;
                MaxSteps = 45;
                VisitedPosition = new bool[50];
                MapSize = 5;
            }

            // MEDIUM
            else if (difficulty.KeyChar == '1')
            {
                Health = 100;
                MaxHealth = 100;
                MaxSteps = 95;
                VisitedPosition = new bool[100];
                MapSize = 10;
            }

            // HARD
            else if (difficulty.KeyChar == '2')
            {
                Health = 50;
                MaxHealth = 75;
                MaxSteps = 130;
                VisitedPosition = new bool[150];
                MapSize = 15;
            }

            // SUPER EASY
            else
            {
                Health = 1000;
                MaxHealth = 1000;
                MaxSteps = 300;
                VisitedPosition = new bool[30];
                MapSize = 3;
            }
        }

        public void Attack()
        {
            Retaliation();
            HealthPotion();
        }

        public void Flee()
        {
            PreviousPosition.CopyTo(Position, 0);
            Random rdm = new Random();
            int prob = rdm.Next(11);
            if (prob < 1)
            {
                Health -= 10;
            }
        }

        public void HealthPotion()
        {
            Random rnd = new Random();
            int result = rnd.Next(0, 100);
            if (result < 10)
            {
                if (Health < MaxHealth)
                {
                    Health += 10;
                    if (Health > MaxHealth) {
                        Health = MaxHealth;
                    }
                    Console.WriteLine($"As you kill an {enemy.GetRandomName()}, you are by good fortune granted with additional health points. You now have {Health}/{MaxHealth} HP.");
                }
            }
        }

        public void Retaliation()
        {
            Random rnd = new Random();
            int result = rnd.Next(0, 100);
            if (result < 20)
            {
                Health -= 10;
                gui.PadTextWL($"The {enemy.GetRandomName()} hits you back and you lose 10 health points. You now have {Health} health points remaining.");
            }
        }

        public void SetName()
        {
            while (Name.Length < 1)
            {
                gui.PrimaryColor();
                gui.PadTextW("LOG IN");
                gui.ResetColor();
                Console.Write(" [USERNAME]: ");
                Name = Console.ReadLine();
            }
            if (Name == "Thomas")
            {
                Health = 200;
                MaxHealth = 200;
            }
        }

        public int PlayerPosition()
        {
            return (Position[0] * MapSize + Position[1]) + 1;
        }

        public int PlayerPreviousPosition()
        {
            return (PreviousPosition[0] * MapSize + PreviousPosition[1]) + 1;
        }

        public void CheckHealth()
        {
            if (Health < 1)
            {
                gui.Lose();
            }
        }
    }
}

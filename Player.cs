using System;

namespace gik299_project
{
    class Player
    {
        // Instansiering av klasser
        Enemy enemy = new Enemy();
        Menu menu = new Menu();

        public string Name;
        public int Health;
        public int HealthBoundary;
        public int MaxHealth;
        public int Keys;
        public int Potions;
        public int Steps;
        public int MaxSteps;
        public int MapSize;
        public int[] Position;
        public int[] PrevPosition;
        public bool[] VisitedPosition;
        public int EnemiesKilled;

        public void Settings()
        {
            Name = "";
            Health = 100;
            HealthBoundary = 90;
            MaxHealth = 100;
            Keys = 0;
            Potions = 0;
            Steps = 0;
            MaxSteps = 95;
            MapSize = 10;
            Position = new int[2] { 9, 0 };
            PrevPosition = new int[2] { 9, 0 };
            VisitedPosition = new bool[100];
            EnemiesKilled = 0;
        }

        public void Attack()
        {
            AttackProbability();
            HealthBoostChance();
        }

        public void HealthBoostChance()
        {
            Random rnd = new Random();
            int result = rnd.Next(0, 100);
            if (result < 10)
            {
                if (Health > HealthBoundary)
                {
                    Health += MaxHealth - Health;
                    Console.WriteLine($"As you kill an {enemy.GetRandomName()}, you are by good fortune granted with additional health points. You now have {Health}/{MaxHealth} HP.");
                }
                else
                {
                    Health += 10;
                    menu.PadTextWL($"As you kill an {enemy.GetRandomName()}, you are by good fortune granted with an additional 10 health points. You now have {Health}/{MaxHealth} HP.");
                }
            }
        }

        public void AttackProbability()
        {
            Random rnd = new Random();
            int result = rnd.Next(0, 100);
            if (result < 20)
            {
                Health -= 10;
                menu.PadTextWL($"The {enemy.GetRandomName()} hits you back and you lose 10 health points. You now have {Health} health points remaining.");
            }
            // https://social.msdn.microsoft.com/Forums/vstudio/en-US/26f951f7-8d3d-4926-8705-bddc8a5f8873/i-need-help-with-c-numbers-and-percentages-in-a-few-lines-of-code?forum=csharpgeneral
        }

        public void ChooseCharacter()
        {
            Console.WriteLine();
            menu.PadTextWL("[Choose a character]");
            menu.PadTextWL("1: philipsinnott");
            menu.PadTextWL("2: matteh");
            menu.PadTextWL("3: linuz");
            menu.PadTextWL("4: Custom character");
            menu.Indent();
            if (int.TryParse(Console.ReadLine(), out int CharacterMenu))
            {
                switch (CharacterMenu)
                {
                    case 1:
                        Name = "philipsinnott";
                        break;
                    case 2:
                        Name = "matteh";
                        break;
                    case 3:
                        Name = "linuz";
                        break;
                    case 4:
                        menu.PadTextW("Enter the name of your custom character: ");
                        Name = Console.ReadLine();
                        break;
                    case 1337:
                        Name = "Thomas";
                        MaxHealth = 200;
                        break;
                    default:
                        menu.PadTextWL("You must choose an alternative ranging from 1-4.");
                        break;
                }
            }
            else
            {
                menu.PadTextWL("You must enter a valid number.");
            }
        }
        public int PlayerPosition()
        {
            return (Position[0] * MapSize + Position[1]) + 1;
        }

        public int PlayerPrevPosition()
        {
            return (PrevPosition[0] * MapSize + PrevPosition[1]) + 1;
        }

        public void Flee()
        {
            PrevPosition.CopyTo(Position, 0);
            Random rdm = new Random();
            int prob = rdm.Next(11);
            if (prob < 1)
            {
                Health -= 10;
            }
        }

        public void CheckHealth()
        {
            if (Health < 1)
            {
                menu.Lose();
            }
        }
    }
}

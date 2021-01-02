using System;

namespace gik299_project
{
    class Player
    {
        // Instansiering av klasser
        Enemy enemy = new Enemy();
        Map map = new Map();
        Control control = new Control();
        Menu menu = new Menu();
        Highscore highscore = new Highscore();
        SaveLoad saveload = new SaveLoad();

        public string Name;
        public int Health = 100;
        public int HealthBoundary = 90;
        public int MaxHealth = 100;
        public int Keys = 0;
        public int Potions = 0;
        public int Steps = 0;
        public int[] Position = new int[2] { 9, 0 };
        public int[] PrevPosition = new int[2] { 9, 0 };
        public bool[] VisitedPosition = new bool[100];

        public void Movement()
        {

        }

        public void SetName()
        {
            Console.Clear();
            Console.CursorVisible = true;
            menu.PadTextW("\n\n\nPlease tell me your name: ");
            Name = Console.ReadLine();
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

        public void ShowPlayerStats()
        {
            menu.PadTextWL("---STATS---");
            menu.PadTextWL($"Name: {Name}");
            menu.PadTextWL($"Health: {Health}/100 HP");
            menu.PadTextWL($"Keys collected: {Keys}/10");
            menu.PadTextWL($"Steps taken: {Steps}");
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
            return ((Position[0] * 10 + Position[1]) + 1);
        }

        public int PlayerPrevPosition()
        {
            return ((PrevPosition[0] * 10 + PrevPosition[1]) + 1);
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
    }
}

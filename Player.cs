using System;
using System.Collections.Generic;
using System.Text;

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
        public int[] PrevPosition = new int[2];
        public bool[] VisitedPosition = new bool[100];

        public void Movement()
        {

        }

        public void Attack()
        {
            Console.WriteLine($"You attack the {enemy.GetRandomName()}.");
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
                    Console.WriteLine($"As you kill an {enemy.GetRandomName()}, you are by good fortune granted with additional health points. You now have {Health}/{MaxHealth}.");
                }
                else
                {
                    Health += 10;
                    Console.WriteLine($"As you kill an [enemy], you are by good fortune granted with an additional 10 health points. You now have {Health}/{MaxHealth} HP.");
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
                Console.WriteLine($"The [enemy] hits you back and you lose 10 health points. You now have {Health} health points remaining.");
            }
            // https://social.msdn.microsoft.com/Forums/vstudio/en-US/26f951f7-8d3d-4926-8705-bddc8a5f8873/i-need-help-with-c-numbers-and-percentages-in-a-few-lines-of-code?forum=csharpgeneral
        }

        public void ShowPlayerStats()
        {
            Console.WriteLine("---STATS---");
            Console.WriteLine($"Name: {Name}");
            Console.WriteLine($"Health: {Health}/100 HP");
            Console.WriteLine($"Keys collected: {Keys}/10");
            Console.WriteLine($"Steps taken: {Steps}");
        }

        public void ChooseCharacter()
        {
            Console.WriteLine("Choose a character!");
            Console.WriteLine("1: 'philipsinnott'");
            Console.WriteLine("2: 'ImStuffZ'");
            Console.WriteLine("3: 'trixt3r7'");
            Console.WriteLine("4: Custom character");

            if (int.TryParse(Console.ReadLine(), out int CharacterMenu))
            {
                switch (CharacterMenu)
                {
                    case 1:
                        Name = "philipsinnott";
                        break;
                    case 2:
                        Name = "ImStuffZ";
                        break;
                    case 3:
                        Name = "trixt3r7";
                        break;
                    case 4:
                        Console.WriteLine("Enter the name of your custom character!");
                        Name = Console.ReadLine();
                        break;
                    case 1337:
                        Name = "Thomas";
                        MaxHealth = 200;
                        break;
                    default:
                        Console.WriteLine("You must choose an alternative ranging from 1-4.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("You must enter a valid number.");
            }
        }
      
        public void Damage()
        {

        }

        public void CurrentPlayerPosition()
        {
            
        }

        public void Settings()
        {

        }
    }
}

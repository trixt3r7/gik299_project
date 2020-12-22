using System;
using System.Collections.Generic;
using System.Text;

namespace gik299_project
{
    class Player
    {
        public string Name;
        public int Health = 100;
        public int MaxHealth = 100;
        public int Keys = 0;
        public int Potions = 0;
        public int Steps = 0;
        public int[] Position = new int[2] { 9, 0 };
        public int[] PrevPosition = new int[2] {0, 0};
        public bool[] VisitedPosition = new bool[100];


        public void Movement()
        {

        }

        public void Attack()
        {
            Console.WriteLine("You attack the [enemy].");
            AttackProbability();
        }

        public void AttackProbability()
        {
            Random rnd = new Random();
            int result = rnd.Next(1, 100);
            if (result < 20)
            {
                Health -= 10;
                Console.WriteLine($"The [enemy] hits you back and you lose 10 health points. You now have {Health} health points remaining.");
            }
            // https://social.msdn.microsoft.com/Forums/vstudio/en-US/26f951f7-8d3d-4926-8705-bddc8a5f8873/i-need-help-with-c-numbers-and-percentages-in-a-few-lines-of-code?forum=csharpgeneral
        }

        public void Damage()
        {

        }

        public void Settings()
        {

        }
    }
}

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
        public int[] PrevPosition = new int[2] { 9, 0 };
        public bool[] VisitedPosition = new bool[100];

        public void SetName()
        {
            Console.Clear();
            Console.CursorVisible = true;
            Console.Write("\n\n\nPlease tell me your name: ");
            Name = Console.ReadLine();
        }

        public int PlayerPosition()
        {
            return ((Position[0] * 10 + Position[1]) + 1);
        }

        public int PlayerPrevPosition()
        {
            return ((PrevPosition[0] * 10 + PrevPosition[1]) + 1);
        }

        public void Movement()
        {

        }

        public void Action()
        {

        }

        public void Damage()
        {

        }

        public void Settings()
        {

        }
    }
}

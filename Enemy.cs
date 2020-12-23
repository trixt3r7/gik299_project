using System;
using System.Collections.Generic;
using System.Text;

namespace gik299_project
{
    class Enemy
    {

        public string[] Names = new string[] { "Grunt", "Guard", "Assault", "Sniper", "Brute", "Netrunner" };
        public float DropRate;

        public string GetRandomName()
        {
            Random rdm = new Random();
            int index = rdm.Next(Names.Length);
            string RandomName = Names[index];
            return RandomName;
        }

        public void Count()
        {
            Random rnd = new Random();

        }

        public void Position()
        {

            Random rnd = new Random();
            int[] position = new int[10];

            foreach (int p in position)
            {
                position[p] = rnd.Next(0, 100);
            }
        }    
    }
}

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

        public int[] EnemyCount()
        {
            Random rnd = new Random();
            int randomizer = rnd.Next(1, 4);
            int count = 10;
            int[] enemyCount = new int[count];
            for (int i = 0; i < count; i++)
            {
                enemyCount[i] = randomizer;
            }
            return enemyCount;
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

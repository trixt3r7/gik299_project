using System;
using System.Collections.Generic;

namespace gik299_project
{
    class Enemy
    {

        public string[] Names = new string[] { "Grunt", "Guard", "Assault", "Sniper", "Brute", "Netrunner" };
        public float DropRate;
        public List<int> TotalEnemies;

        public string GetRandomName()
        {
            Random rdm = new Random();
            int index = rdm.Next(Names.Length);
            string RandomName = Names[index];
            return RandomName;
        }

        public void GenerateEnemies()
        {
            TotalEnemies = EnemyPos();
        }

        public int[] EnemyCount()
        {
            Random rnd = new Random();
            int randomizer = rnd.Next(3);
            int count = 10;
            int[] enemyCount = new int[count];
            for (int i = 0; i < count; i++)
            {
                enemyCount[i] = randomizer;
            }
            return enemyCount;
        }

        public List<int> EnemyPos()
        {

            List<int> randomNumbers = new List<int>();
            Random rng = new Random();

            for (int i = 0; i < 10; i++)
            {
                int numberToAdd;

                do numberToAdd = rng.Next(1, 100);
                while (randomNumbers.Contains(numberToAdd) || numberToAdd == 91 || numberToAdd == 10);

                randomNumbers.Add(numberToAdd);
            }
            return randomNumbers;
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

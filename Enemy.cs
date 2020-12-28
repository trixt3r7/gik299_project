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
        private int enemyCount;

        public static int[] EnemyCount()
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

        
        public void CheckEnemiesLeft()
        {
            if (enemyCount == 0)
            {
                Console.WriteLine($"You enter a room with an {GetRandomName()} but he's asleep and doesn't hear you, where to next?");
            }
            else if (enemyCount == 1)
            {
                Console.WriteLine($"You enter a room where a {GetRandomName()} sees you. What do you do?");
            }
            else if (enemyCount == 2)
            {
                Console.WriteLine($"You enter a room with [2] enemies, a {GetRandomName()} and a {GetRandomName()}. What do you do?");
            }
            else if (enemyCount == 3)
            {
                Console.WriteLine($"- You enter a room with [3] enemies a {GetRandomName()}, {GetRandomName()} and {GetRandomName()}. What do you do?");
            }
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

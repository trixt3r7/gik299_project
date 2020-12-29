using System;
using System.Collections.Generic;

namespace gik299_project
{
    class Enemy
    {

        public string[] Names = new string[] { "Grunt", "Guard", "Assault", "Sniper", "Brute", "Netrunner" };
        public float DropRate;
        public List<int> Positions;
        public int[] EnemyCounts = new int[10];
        public int count = 10;

        Control control = new Control();
        Menu menu = new Menu();

        public string GetRandomName()
        {
            Random rdm = new Random();
            int index = rdm.Next(Names.Length);
            string RandomName = Names[index];
            return RandomName;
        }

        public void GenerateEnemies()
        {
            Positions = EnemyPosition();
            EnemyCounts = EnemyCount();
        }

        public int[] EnemyCount()
        {
            Random rnd = new Random();
            int randomizer = rnd.Next(1, 4);
            int[] enemyCount = new int[count];
            for (int i = 0; i < count; i++)
            {
                enemyCount[i] = randomizer;
            }
            return enemyCount;
        }

        public void ComparePos()
        {

        }

        public void CheckForEnemies(Player player)
        {
            for (int i = 0; i < count; i++)
            {
                if (player.PlayerPosition() == Positions[i])
                {
                    Console.Beep(80, 200);

                    //PÅ DEN HÄR RADEN SKA MAN HAMNA I EN FIGHT.
                    // Positions[i] = 0;

                    if (EnemyCounts[i] == 0)
                    {
                        Console.WriteLine($"You enter a room with an {GetRandomName()} but he's asleep and doesn't hear you, where to next?");
                    }
                    else if (EnemyCounts[i] == 1)
                    {
                        Console.WriteLine($"You enter a room where a {GetRandomName()} sees you. What do you do?");
                    }
                    else if (EnemyCounts[i] == 2)
                    {
                        Console.WriteLine($"You enter a room with [2] enemies, a {GetRandomName()} and a {GetRandomName()}. What do you do?");
                    }
                    else if (EnemyCounts[i] == 3)
                    {
                        Console.WriteLine($"- You enter a room with [3] enemies a {GetRandomName()}, {GetRandomName()} and {GetRandomName()}. What do you do?");
                    }
                    else
                    {
                        Console.WriteLine("bla");
                    }
                    menu.FightMenu();
                    control.PlayerAction(player);
                }
            }
        }

        public List<int> EnemyPosition()
        {

            List<int> randomNumbers = new List<int>();
            Random rng = new Random();

            for (int i = 0; i < count; i++)
            {
                int numberToAdd;

                do numberToAdd = rng.Next(1, 100);
                while (randomNumbers.Contains(numberToAdd) || numberToAdd == 91 || numberToAdd == 10);

                randomNumbers.Add(numberToAdd);
            }
            return randomNumbers;
        }

        /* public void Position()
        {
            Random rnd = new Random();
            int[] position = new int[10];

            foreach (int p in position)
            {
                position[p] = rnd.Next(0, 100);
            }
         } */
    }
}

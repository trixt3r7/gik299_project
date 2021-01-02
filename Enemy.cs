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
            int[] enemyCount = new int[count];
            for (int i = 0; i < count; i++)
            {
                enemyCount[i] = rnd.Next(1, 4);
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
                    if (EnemyCounts[i] == 1)
                    {
                        menu.PadTextWL($"You enter a room where a {GetRandomName()} sees you. What do you do?");
                        menu.FightMenu();
                        CheckEnemiesLeft(player, i);
                        break;
                    }

                    else if (EnemyCounts[i] == 2)
                    {
                        menu.PadTextWL($"You enter a room with 2 enemies, a {GetRandomName()} and a {GetRandomName()}. What do you do?");
                        menu.FightMenu();
                        CheckEnemiesLeft(player, i);
                        break;
                    }
                    else if (EnemyCounts[i] == 3)
                    {
                        menu.PadTextWL($"You enter a room with 3 enemies, a {GetRandomName()}, a {GetRandomName()} and a {GetRandomName()}. What do you do?");
                        menu.FightMenu();
                        CheckEnemiesLeft(player, i);
                        break;
                    }
                }
            }
        }

        public void CheckEnemiesLeft(Player player, int i)
        {
            while (EnemyCounts[i] > 0)
            {
                string ActionEvent = control.PlayerAction(player);
                if (ActionEvent == "attack")
                {
                    EnemyCounts[i]--;
                    if (EnemyCounts[i] > 0)
                    {
                        menu.PadTextWL($"There are {EnemyCounts[i]} enemies left to fight.");
                    }
                    else if (EnemyCounts[i] == 0)
                    {
                        menu.PadTextWL("You have eliminated all enemies in this room. Where to next?");
                    }
                }
                else if (ActionEvent == "flee")
                {
                    menu.PadTextWL("You successfully flee and rebound to your previous location.");
                    break;
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
    }
}

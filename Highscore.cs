using System;
using System.Collections.Generic;
using System.Text;

namespace gik299_project
{
    class Highscore
    {
        int Score = 1000;
        const int StartingScore = 1000;
        Dictionary<string, int> players = new Dictionary<string, int>();

        Player player = new Player();
        public void CalculateScore()
        {
            string playerName = player.Name;
            int playerSteps = player.Steps *= 10;
            int playerKills = player.EnemiesKilled *= 50;
            int playerHealth = player.Health *= (int)0.0025 + 1;
            // multiplier ?

            int totalScore = playerHealth * (Score - playerSteps) + playerKills;
            players.Add(playerName, totalScore);
        }

        public void ListPlayers()
        {
            foreach (KeyValuePair<string, int> entry in players)
            {
                Console.WriteLine($"Output: {entry}");
            }
        }

        public void TopTenList()
        {

        }
    }
}

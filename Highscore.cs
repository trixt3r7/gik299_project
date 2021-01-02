using System;
using System.Collections.Generic;
using System.Text;

namespace gik299_project
{
    class Highscore
    {
        int Score = 1000;
        const int StartingScore = 1000;


        public string CalculateScore(Player player)
        {
            string playerName = player.Name;
            int playerSteps = player.Steps *= 10;
            int playerKills = player.EnemiesKilled *= 10;
            int playerHealth = (player.Health *= (int)0.0025) + 1;
            // multiplier ?

            int totalScore = playerHealth * (Score - playerSteps) + playerKills;
            return ($"{playerName} | {totalScore}");
        }

        public void ListPlayers()
        {

        }

        public void TopTenList()
        {

        }
    }
}

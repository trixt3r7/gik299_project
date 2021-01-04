using System;
using System.Collections.Generic;
using System.Text;

namespace gik299_project
{
    class Highscore
    {
        int Score = 1000;
        const int StartingScore = 1000;

        public string CalculateScore(Player player, ConsoleKeyInfo difficulty)
        {
            string playerName = player.Name;
            int playerSteps = player.Steps *= 10;
            int playerKills = player.EnemiesKilled *= 10;
            int playerHealth = (player.Health *= (int)0.025) + 1;
            float multiplier = 1f;

            // EASY
            if (difficulty.KeyChar == '0')
            {
                multiplier = 1f;
            }

            // MEDIUM
            if (difficulty.KeyChar == '1')
            {
                multiplier = 1.25f;
            }

            // HARD
            if (difficulty.KeyChar == '2')
            {
                multiplier = 1.5f;
            }

            // SUPEREASY
            if (!(difficulty.KeyChar == '0' || difficulty.KeyChar == '1' || difficulty.KeyChar == '2'))
            {
                multiplier = 0.25f;
            }

            float totalScore = multiplier * (playerHealth * (Score - playerSteps) + playerKills);
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

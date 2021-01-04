using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.Json;

namespace gik299_project
{
    class Highscore
    {

        List<Highscore> highscore = new List<Highscore>();
        Player highscores = new Player();
        string path = "Highscore.json";

        public string CalculateScore(Player player)
        {
            int playerSteps = player.Steps *= 10;
            int playerKills = player.EnemiesKilled *= 10;
            int playerHealth = (player.Health *= (int)0.025) + 1;
            // multiplier ?

            int playerScore = player.Score;

            int totalScore = playerHealth * (playerScore - playerSteps) + playerKills;

            highscores.Name = player.Name;
            highscores.Score = player.Score;

            return ("");
        }

        public void ListPlayers(Player player)
        {
            if (!File.Exists(path))
            {
                var newFile = File.Create(path);
                newFile.Close();
                List<Player> playerList = new List<Player>();
                playerList.Add(highscores);
                var jsonData = ConvertToJson(playerList);
                WriteAllText(jsonData);
            }
            if (new FileInfo(path).Length > 0)
            {

            }
        }

        static string ConvertToJson(List<Player> data)
        {
            string json = JsonSerializer.Serialize<List<Player>>(data);
            return json;
        }

        static void WriteAllText(string text)
        {
            string path = "Highscore.json";
            File.WriteAllText(path, text);
        }
        static void AppendAllText(string text)
        {
            string path = "Highscore.json";
            File.AppendAllText(path, text);
        }
    }
}

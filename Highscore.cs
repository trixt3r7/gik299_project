using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace gik299_project
{
    [Serializable]
    class Highscore
    {
        static GUI gui = new GUI();

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
            else if (difficulty.KeyChar == '1')
            {
                multiplier = 1.25f;
            }

            // HARD
            else if (difficulty.KeyChar == '2')
            {
                multiplier = 1.5f;
            }

            // SUPEREASY
            else (!(difficulty.KeyChar == '0' || difficulty.KeyChar == '1' || difficulty.KeyChar == '2'))
            {
                multiplier = 0.25f;
            }

            float totalScore = multiplier * (playerHealth * (Score - playerSteps) + playerKills);
            return ($"{playerName} | {totalScore}");
        }

        // List will contain all names and scores
        static List<Highscore> highscoreList = new List<Highscore>();

        // Path to savefile
        string path = "Highscore.json";

        public string Name { get; set; }
        public int Score { get; set; }

        public void AddHighScore(Player player)
        {
            Highscore highscore = new Highscore();
            int playerSteps = player.Steps * 10;
            int playerKills = player.EnemiesKilled * 20;
            int playerHealth = (int)((player.Health * 0.025f) + 1);

            highscore.Name = player.Name;
            highscore.Score = playerHealth * (player.Score - playerSteps) + playerKills;
            highscoreList.Add(highscore);

            var fileData = ConvertToJson(highscoreList);
            WriteAllText(path, fileData);
        }

        public void ShowHighScore()
        {
            gui.PadTextWL($"NAME\t\tSCORE");
            foreach (Highscore score in highscoreList)
            {
                gui.PadTextWL($"{score.Name}\t\t{score.Score}");
            }
        }

        public void LoadFile()
        {
            if (!File.Exists(path))
            {
                var myFile = File.Create(path);
                myFile.Close();
            }
            if (new FileInfo(path).Length > 0)
            {
                highscoreList = ReadFromFile(path);
            }
            else
            {
                //Console.WriteLine("No savedata found in {0}", path); //DEBUG
            }
        }

        // Read JSON-file and Deserialize to a List
        static List<Highscore> ReadFromFile(string path)
        {
            string fileContent = File.ReadAllText(path);
            List<Highscore> highscoreList = JsonSerializer.Deserialize<List<Highscore>>(fileContent);
            return highscoreList;
        }

        static string ConvertToJson(List<Highscore> data)
        {
            string json = JsonSerializer.Serialize(data);
            return json;
        }

        static void WriteAllText(string path, string text)
        {
            File.WriteAllText(path, text);
        }
    }
}

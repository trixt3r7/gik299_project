using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace gik299_project
{
    [Serializable] // Added Serializable
    class Highscore
    {
        static GUI gui = new GUI();

        // List will contain all names and scores
        static List<Highscore> highscoreList = new List<Highscore>();

        // Path to file
        string path = "Highscore.json";

        // Unknown about row below
        //Player highscores = new Player();

        // Added two variables that will be used for High Score
        public string Name { get; set; }
        public int Score { get; set; }

        // Rewrite this method below (AddHighScore) [OLD]
        //public string CalculateScore(Player player)
        //{
        //    int playerSteps = player.Steps *= 10;
        //    int playerKills = player.EnemiesKilled *= 10;
        //    int playerHealth = (player.Health *= (int)0.025) + 1;
        //    // multiplier ?

        //    int playerScore = player.Score;

        //    int totalScore = playerHealth * (playerScore - playerSteps) + playerKills;

        //    highscores.Name = player.Name;
        //    highscores.Score = player.Score;

        //    return "";
        //}
        public void AddHighScore(Player player)
        {
            Highscore highscore = new Highscore();
            int playerSteps = player.Steps * 10;
            int playerKills = player.EnemiesKilled * 20;
            int playerHealth = (player.Health * (int)0.025) + 1;

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

        // New method based on below method with another name and with adjustments
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
                Console.WriteLine("{0} has no saved data.", path);
            }
        }

        //public void ListPlayers(string path)
        //{
        //    if (!File.Exists(path))
        //    {
        //        var newFile = File.Create(path);
        //        newFile.Close();
        //        List<Player> playerList = new List<Player>();
        //        playerList.Add(highscores);
        //        var jsonData = ConvertToJson(playerList);
        //        WriteAllText(jsonData);
        //    }
        //    if (new FileInfo(path).Length > 0)
        //    {

        //    }
        //}

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

        static void WriteAllText(string path, string text) // Added path as parameter and commented it out below
        {
            //string path = "Highscore.json"; 
            File.WriteAllText(path, text);
        }
        static void AppendAllText(string text)
        {
            string path = "Highscore.json";
            File.AppendAllText(path, text);
        }
    }
}

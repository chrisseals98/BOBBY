using System;
using System.Text.Json;
using System.IO;

namespace Bucstop.Services
{
    public class PlayCountManager
    {
        private List<GamePlayCount> gamePlayCounts;

        public PlayCountManager(string jsonFilePath)
        {
            LoadPlayCounts(jsonFilePath);
        }

        public void IncrementPlayCount(int gameId)
        {
            var game = gamePlayCounts.FirstOrDefault(x => x.GameId == gameId);
            if (game != null)
            {
                game.PlayCount++;
                SaveplayCounts();
            }
        }

        public int GetPlayCount(int gameId)
        {
            var game = gamePlayCounts.FirstOrDefault(x => x.GameId == gameId);
            return game?.PlayCount ?? 0;
        }

        private void LoadPlayCounts(string jsonFilePath)
        {
            var jsonText = File.ReadAllText(jsonFilePath);
            gamePlayCounts = JsonSerializer.Deserialize<List<GamePlayCount>>(jsonText);
        }

        private void SaveplayCounts()
        {
            var jsonText = JsonSerializer.Serialize(gamePlayCounts);
            File.WriteAllText(jsonFilePath, jsonText);
        }
    }

}
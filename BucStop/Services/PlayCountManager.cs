using BucStop.Models;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace BucStop.Services
{

    public class PlayCountManager
    {
        private List<GamePlayCount> gamePlayCounts;
        private string jsonFilePath;  // Field to store the JSON file path

        public PlayCountManager(IWebHostEnvironment webHostEnvironment)
        {
            jsonFilePath = Path.Combine(webHostEnvironment.WebRootPath, "playcount.json");
            LoadPlayCounts();
        }


        public void IncrementPlayCount(int gameId)
        {
            var game = gamePlayCounts.FirstOrDefault(g => g.GameId == gameId);
            if (game != null)
            {
                game.PlayCount++;
                SavePlayCounts();
            }
        }

        public int GetPlayCount(int gameId)
        {
            var game = gamePlayCounts.FirstOrDefault(g => g.GameId == gameId);
            return game?.PlayCount ?? 0;
        }

        private void LoadPlayCounts()
        {
            var jsonText = File.ReadAllText(jsonFilePath);
            gamePlayCounts = JsonSerializer.Deserialize<List<GamePlayCount>>(jsonText);
        }

        private void SavePlayCounts()
        {
            var jsonText = JsonSerializer.Serialize(gamePlayCounts);
            File.WriteAllText(jsonFilePath, jsonText);
        }
    }
}
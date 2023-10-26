 using BucStop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BucStop.Controllers
{
    public class GamesController : Controller
    {
        private readonly MicroClient _httpClient;
        public GamesController(MicroClient games) 
        {
            _httpClient = games; 
        }
        
        private static List<Game> games = new List<Game>
        {
            
            // Game data
            new Game { 
                Id = 1, 
                Title = "Snake", 
                Content = "~/js/snake.js",
                Author = "Author",
                Description = "Snake Description",
                HowTo = "How to play.",
                Thumbnail = "/images/snake.jpg" //640x360 resolution
            },
            new Game { 
                Id = 2, 
                Title = "Tetris", 
                Content = "~/js/tetris.js",
                Author = "Tetris description.",
                Description = "Tetris description.",
                HowTo = "How to play.",
                Thumbnail = "/images/tetris.jpg"
            },
            new Game {
                Id = 3,
                Title = "Pong",
                Content = "~/js/pong.js",
                Author = "Pong description.",
                Description = "Pong description.",
                HowTo = "How to play.",
                Thumbnail = "/images/pong.jpg"
            },
        };

        // GET: Game

        public IActionResult Index()
        {
            return View(games);
        }

        public async Task<IActionResult> Play(int id)
        {
            GameInfo[] _games = await _httpClient.GetGamesAsync();
            Game game = games.FirstOrDefault(x => x.Id == id);
            if (game == null)
            {
                return NotFound();
            }

            return View(game);
        }

        public IActionResult Snake()
        {
            return View();
        }
        public IActionResult Tetris()
        {
            return View();
        }
    }
}

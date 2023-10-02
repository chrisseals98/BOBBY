using BucStop.Models;
using Microsoft.AspNetCore.Mvc;

namespace BucStop.Controllers
{
    public class GamesController : Controller
    {
        private static List<Game> games = new List<Game>
        {
            // Game data
            new Game { 
                Id = 1, 
                Title = "Snake", 
                Content = "~/js/snake.js",
                Author = "Author",
                Description = "Description",
                HowTo = "How to play"
            },
            new Game { 
                Id = 2, 
                Title = "Tetris", 
                Content = "~/js/tetris.js",
                Author = "Tetris description.",
                Description = "Tetris description.",
                HowTo = "Tetris description."
            }
        };

        // GET: Game
        public IActionResult Index()
        {
            return View(games);
        }

        public IActionResult Play(int id)
        {
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

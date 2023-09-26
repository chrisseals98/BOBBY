using BucStop.Models;
using Microsoft.AspNetCore.Mvc;

namespace BucStop.Controllers
{
    public class GamesController : Controller
    {
        private static List<Game> games = new List<Game>
        {
            // Sample data - replace with database or other data source
            new Game { Id = 1, Title = "Sample Game 1", Content = "Embed code or URL for Game 1", Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum. Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum." },
            new Game { Id = 2, Title = "Sample Game 2", Content = "Embed code or URL for Game 2", Description = "Game 2 description." }
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

using BucStop.Models;
using BucStop.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;

/*
 * This file handles the links to each of the game pages.
 */

namespace BucStop.Controllers
{
    [Authorize]
    public class GamesController : Controller
    {
        private readonly MicroClient _httpClient;
        private readonly PlayCountManager _playCountManager;
        private readonly GameService _gameService;

        public GamesController(MicroClient games, IWebHostEnvironment webHostEnvironment, GameService gameService)
        {
            _httpClient = games;
            _gameService = gameService;

            // Initialize the PlayCountManager with the web root path and the JSON file name
            _playCountManager = new PlayCountManager(_gameService.GetGames() ?? new List<Game>(), webHostEnvironment);

            
        }

        //Takes the user to the index page, passing the games list as an argument
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Index()
        {
            return View(_gameService.GetGames());
        }

        //Takes the user to the Play page, passing the game object the user wants to play
        public async Task<IActionResult> Play(int id)
        {
            GameInfo[] _gamesInfo = await _httpClient.GetGamesAsync();
            List<Game> games = _gameService.GetGames() ?? new List<Game>();

            Game game = games.FirstOrDefault(x => x.Id == id);
            if (game == null)
            {
                return NotFound();
            }

            // Increment the play count for the game with the specified ID
            _playCountManager.IncrementPlayCount(id);

            int playCount = _playCountManager.GetPlayCount(id);

            // Update the game's play count
            game.PlayCount = playCount;

            if (_games.Length == 0)
            {
                return View(game);
            }
            if (game.Id == 1)
            {
                game.Author = _games[0].Author;
                game.HowTo = _games[0].HowTo;
                game.DateAdded = _games[0].DateAdded;
                game.Description = $"{_games[0].Description} /n {_games[0].DateAdded}";
            }
            if( game.Id == 2) 
            {
                game.Author = _games[1].Author;
                game.HowTo = _games[1].HowTo;
                game.DateAdded = _games[1].DateAdded;
                game.Description = $"{_games[1].Description} /n {_games[1].DateAdded}";
            }
            if (game.Id == 3)
            {
                game.Author = _games[2].Author;
                game.HowTo = _games[2].HowTo;
                game.DateAdded = _games[2].DateAdded;
                game.Description = $"{_games[2].Description} /n {_games[2].DateAdded}";
            }

            return View(game);
        }

        //Takes the user to the deprecated snake page
        public IActionResult Snake()
        {
            return View();
        }

        //Takes the user to the deprecated tetris page
        public IActionResult Tetris()
        {
            return View();
        }
    }
}

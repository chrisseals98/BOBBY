 using BucStop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BucStop.Controllers
{
    public class GamesController : Controller
    {
        private readonly MicroClient _httpClient;

        private static readonly GameInfo[] gameInfos;

        public GamesController(MicroClient games) 
        {
            _httpClient = games; 

        }

        private static List<Game> games = new List<Game>
        {


            //Game data
            new Game { 
                Id = 1, 
                Title = "Snake", 
                Content = "~/js/snake.js",
                Author = null, 
                Description = "Snake Description",
                HowTo = null,
                Thumbnail = "/images/snake.jpg" //640x360 resolution
            },
            new Game { 
                Id = 2, 
                Title = "Tetris", 
                Content = "~/js/tetris.js",
                Author = null,
                Description = "Tetris description.",
                HowTo = null,
                Thumbnail = "/images/tetris.jpg"
            },
            new Game {
                Id = 3,
                Title = "Pong",
                Content = "~/js/pong.js",
                Author = null,
                Description = "Pong description.",
                HowTo = null,
                Thumbnail = "/images/pong.jpg"
            },
        };

        // GET: Game

        public async Task<IActionResult> Play(int id)
        {
            GameInfo[] _games = await _httpClient.GetGamesAsync();
            
            Game game = games.FirstOrDefault(x => x.Id == id);
            if (game == null)
            {
                return NotFound();
            }
            if(game.Id == 1)
            {
                game.Author = _games[0].Author;
                game.HowTo = _games[0].HowTo;
            }
            if( game.Id == 2) 
            {
                game.Author = _games[1].Author;
                game.HowTo = _games[1].HowTo;
            }
            if (game.Id == 3)
            {
                game.Author = _games[2].Author;
                game.HowTo = _games[2].HowTo;
            }

            return View(game);
        }
        public IActionResult Index()
        {
            return View(games);
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

using BucStop.Models;
using Microsoft.AspNetCore.Mvc;

/*
 * This file handles the links to each of the game pages.
 */

namespace BucStop.Controllers
{
    public class GamesController : Controller
    {
        //Creating the games objects to display on Play and Index
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

        //Takes the user to the index page, passing the games list as an argument
        public IActionResult Index()
        {
            return View(games);
        }

        //Takes the user to the Play page, passing the game object the user wants to play
        public IActionResult Play(int id)
        {
            Game game = games.FirstOrDefault(x => x.Id == id);
            if (game == null)
            {
                return NotFound();
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

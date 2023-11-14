﻿using BucStop.Models;
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


        public GamesController(MicroClient games, IWebHostEnvironment webHostEnvironment)
        {
            _httpClient = games;

            // Initialize the PlayCountManager with the web root path and the JSON file name
            _playCountManager = new PlayCountManager(webHostEnvironment);
        }

        //Creating the games objects to display on Play and Index
        private static List<Game> games = new List<Game>
        {
            //Game data
            new Game { 
                Id = 1, 
                Title = "Snake", 
                Content = "~/js/snake.js",
                Author = null, 
                DateAdded = null,
                Description = "Snake Description",
                HowTo = null,
                Thumbnail = "/images/snake.jpg" //640x360 resolution
            },
            new Game { 
                Id = 2, 
                Title = "Tetris", 
                Content = "~/js/tetris.js",
                Author = null,
                DateAdded = null,
                Description = "Tetris description.",
                HowTo = null,
                Thumbnail = "/images/tetris.jpg"
            },
            new Game {
                Id = 3,
                Title = "Pong",
                Content = "~/js/pong.js",
                Author = null,
                DateAdded = null,
                Description = "Pong description.",
                HowTo = null,
                Thumbnail = "/images/pong.jpg"
            },
        };

        //Takes the user to the index page, passing the games list as an argument
        public IActionResult Index()
        {
            return View(games);
        }

        //Takes the user to the Play page, passing the game object the user wants to play
        public async Task<IActionResult> Play(int id)
        {
            GameInfo[] _games = await _httpClient.GetGamesAsync();

            Game game = games.FirstOrDefault(x => x.Id == id);
            if (game == null)
            {
                return NotFound();
            }
            if(_games.Length == 0)
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Microsoft.Extensions.Caching.Distributed;
using System.Text.Json;

namespace Micro
{
    [ApiController]
    [Route("[controller]")]
    public class MicroController : ControllerBase
    {
        private static readonly List<GameInfo> TheInfo = new List<GameInfo>
        {
            new GameInfo { 
                //Id = 1,
                Title = "Snake",
                //Content = "~/js/snake.js",
                Author = "Hillary clinton ",
                Description = "Look at me im a SNEEEEK",
                HowTo = "Just snek around",
                //Thumbnail = "/images/snake.jpg" //640x360 resolution
            },
            new GameInfo { 
                //Id = 2,
                Title = "Tetris",
                //Content = "~/js/tetris.js",
                Author = "Steve from minecraft",
                Description = "Block Block Block",
                HowTo = "Put Blocks Down",
                //Thumbnail = "/images/tetris.jpg"
            },
            new GameInfo { 
                //Id = 3,
                Title = "Pong",
                //Content = "~/js/pong.js",
                Author = "Forest Gump",
                Description = "Hit the ball",
                HowTo = "Hit the back back",
                //Thumbnail = "/images/pong.jpg"
            },

        };

        private readonly ILogger<MicroController> _logger;

        public MicroController(ILogger<MicroController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<GameInfo> Get()
        {
            return TheInfo;
        }
    }
}

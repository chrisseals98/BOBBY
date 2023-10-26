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
        private static readonly GameInfo[] TheInfo = new[]
        {
            new GameInfo { Title = "Snake", Author = "Kill me ", Description = "Its fucking snake youve played this ", HowTo = "yes"},
            new GameInfo { Title = "Tetris", Author = "Kill me now",  Description= "Its tetris are you stupid", HowTo = "no"},
            new GameInfo { Title = "Pong", Author = "seriously kill me", Description = "Comeon it pong", HowTo = "yes"},

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

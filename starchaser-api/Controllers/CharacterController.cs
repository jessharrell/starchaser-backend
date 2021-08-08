using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using starchaser_api.Models;

namespace starchaser_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ILogger<CharacterController> _logger;

        public CharacterController(ILogger<CharacterController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Character> Get()
        {
            var staticPlanet = new Planet { Id = 0, Name = "Foo", Description = "Some hardcoded planet" };
            var staticCharacter = new Character { Id = 123, Name = "Bar", Health = 7, Homeplanet = staticPlanet, Bio = "Some hardcoded character" };
            return new List<Character> { staticCharacter };
        }
    }
}

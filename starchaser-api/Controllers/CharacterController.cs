using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using starchaser_api.Models;
using starchaser_api.Services;

namespace starchaser_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CharacterController : ControllerBase
    {
        private readonly ILogger<CharacterController> _logger;
        private readonly IDatabaseConnectionService _databaseConnectionService;

        public CharacterController(ILogger<CharacterController> logger, IDatabaseConnectionService databaseConnectionService)
        {
            _logger = logger;
            _databaseConnectionService = databaseConnectionService;
        }

        [HttpGet]
        public async Task<IEnumerable<Character>> Get()
        {
            await _databaseConnectionService.Connect();
            var characters = _databaseConnectionService.GetCharacters();
            await _databaseConnectionService.Disconnect();
            return characters;
        }

        [HttpGet("{id:int}")]
        public async Task<Character> Get(int id)
        {
            await _databaseConnectionService.Connect();
            var character = _databaseConnectionService.GetCharacter(id);
            await _databaseConnectionService.Disconnect();
            return character;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using starchaser_api.Models;

namespace starchaser_api.Services
{
    public interface IDatabaseConnectionService : IAsyncDisposable
    {
        Task Connect();
        Task Disconnect();
        Character GetCharacter(int id);
        IEnumerable<Character> GetCharacters();
    }
}

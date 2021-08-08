using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Npgsql;
using starchaser_api.Models;

namespace starchaser_api.Services
{
    public class DatabaseConnectionService : IDatabaseConnectionService
    {
        private static readonly string connectionString = "Host=localhost;Username=docker;Password=docker;Database=postgres";
        private readonly NpgsqlConnection Connection;

        public DatabaseConnectionService()
        {
            Connection = new NpgsqlConnection(connectionString);
        }

        public async Task Connect()
        {
            await Connection.OpenAsync();
        }

        public async Task Disconnect()
        {
            await Connection.CloseAsync();
        }

        public async ValueTask DisposeAsync()
        {
            await Disconnect();
        }

        public Character GetCharacter(int id)
        {
            var query = $"SELECT * " +
                        $"FROM CHARACTERS " +
                        $"INNER JOIN PLANETS " +
                            $"ON CHARACTERS.planetId = PLANETS.planetId " +
                        $"WHERE CHARACTERS.characterId = {id}";

            return Connection.Query<Character, Planet, Character>(query,
                                                                  (c, p) => { c.Planet = p; return c; },
                                                                  splitOn: "planetId")
                             .FirstOrDefault();
        }

        public IEnumerable<Character> GetCharacters()
        {
            var query = "SELECT * " +
                        "FROM CHARACTERS " +
                        "INNER JOIN PLANETS " +
                            "ON CHARACTERS.planetId = PLANETS.planetId";


            return Connection.Query<Character, Planet, Character>(query,
                                                                  (c, p) => { c.Planet = p; return c; },
                                                                  splitOn: "planetId");
        }
    }
}

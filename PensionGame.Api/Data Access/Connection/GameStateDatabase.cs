using MongoDB.Driver;
using PensionGame.Api.Data_Access.ConnectionSettings;
using PensionGame.Api.Data_Access.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionGame.Api.Data_Access.Connection
{
    public sealed class GameStateDatabase
    {
        private readonly IMongoCollection<GameState> _gameStates;

        public GameStateDatabase(GameStateConnectionSettings pensionGameConnectionSettings)
        {
            var client = new MongoClient(pensionGameConnectionSettings.ConnectionString);
            var database = client.GetDatabase(pensionGameConnectionSettings.DatabaseName);

            _gameStates = database.GetCollection<GameState>(pensionGameConnectionSettings.CollectionName);
        }

        public async Task Create(Guid sessionId, Domain.Resources.GameData.GameState gameState)
        {
            var newGameState = new GameState
            {
                Guid = sessionId,
                Game = gameState
            };

            await _gameStates.InsertOneAsync(newGameState);
        }

        public async Task<IEnumerable<GameState>> GetAll(Guid guid)
        {
            var result = await _gameStates.FindAsync(gameState => gameState.Guid == guid);

            return result.ToList();
        }
    }
}

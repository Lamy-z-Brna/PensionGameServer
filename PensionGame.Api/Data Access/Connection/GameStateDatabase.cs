using MongoDB.Driver;
using PensionGame.Api.Data_Access.ConnectionSettings;
using PensionGame.Api.Data_Access.Data_Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PensionGame.Api.Data_Access.Connection
{
    public sealed class GameStateDatabase : Database<GameState>
    {
        private IMongoCollection<GameState> GameStates => ObjectCollection;

        public GameStateDatabase(GameStateDatabaseSettings gameStateDatabaseSettings, DatabaseConnectionSettings databaseConnectionSettings)
            : base(gameStateDatabaseSettings, databaseConnectionSettings)
        {
        }

        public async Task Create(Guid sessionId, Core.Domain.GameData.GameState gameState)
        {
            var newGameState = new GameState
            {
                Guid = sessionId,
                Game = gameState
            };

            await GameStates.InsertOneAsync(newGameState);
        }

        public async Task<IEnumerable<GameState>> GetAll(Guid guid)
        {
            var result = await GameStates.FindAsync(gameState => gameState.Guid == guid);

            return result.ToEnumerable();
        }

        public async Task<IEnumerable<GameState>> GetAll(IEnumerable<Guid> guids)
        {
            var filter = Builders<GameState>.Filter.In(gameState => gameState.Guid, guids.Cast<Guid?>());

            var result = await GameStates.FindAsync(filter);

            return result.ToEnumerable();
        }
    }
}

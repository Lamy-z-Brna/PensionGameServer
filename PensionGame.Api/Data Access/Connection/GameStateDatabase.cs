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

        public GameStateDatabase(GameStateConnectionSettings pensionGameConnectionSettings) : base(pensionGameConnectionSettings)
        {
        }

        public async Task Create(Guid sessionId, Domain.Resources.GameData.GameState gameState)
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

            return result.ToList();
        }
    }
}

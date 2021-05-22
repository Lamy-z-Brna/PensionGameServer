using PensionGame.Api.Data_Access.Connection;
using PensionGame.Api.Domain.Resources.Session;
using PensionGame.Core.Domain.GameData;
using System.Threading.Tasks;

namespace PensionGame.Api.Data_Access.Writers.GameData
{
    public class GameStateWriter : IGameStateWriter
    {
        private readonly GameStateDatabase _gameStateDatabase;

        public GameStateWriter(GameStateDatabase gameStateDatabase)
        {
            _gameStateDatabase = gameStateDatabase;
        }

        public async Task Create(SessionId sessionId, GameState gameState)
        { 
            await _gameStateDatabase.Create(sessionId.Id, gameState);
        }
    }
}

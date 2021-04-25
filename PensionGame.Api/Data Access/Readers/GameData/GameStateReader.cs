using MongoDB.Driver;
using PensionGame.Api.Data_Access.Connection;
using PensionGame.Api.Domain.Resources.GameData;
using PensionGame.Api.Domain.Resources.Session;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PensionGame.Api.Data_Access.Readers.GameData
{
    public class GameStateReader : IGameStateReader
    {
        private readonly GameStateDatabase _gameStateDatabase;

        public GameStateReader(GameStateDatabase gameStateDatabase)
        {
            _gameStateDatabase = gameStateDatabase;
        }

        public async Task<GameState?> Get(SessionId sessionId, int year)
        {
            var gameStates = await _gameStateDatabase.GetAll(sessionId.Id);
            var gameState = gameStates
                .Where(gs => gs.Game?.Year == year)
                .FirstOrDefault();

            return gameState?.Game;
        }

        public async Task<Dictionary<int, GameState>> Get(SessionId sessionId)
        {
            var gameStates = await _gameStateDatabase.GetAll(sessionId.Id);
            var gameStatesByYear = gameStates
                .Where(gameState => gameState.Game != null)
                .GroupBy(gameState => gameState.Game!.Year)
                .ToDictionary(kv => kv.Key, g => g.Select(gameState => gameState.Game).First()!);

            return gameStatesByYear;
        }

        public async Task<GameState?> GetCurrentGameState(SessionId sessionId)
        {
            var gameStates = await _gameStateDatabase.GetAll(sessionId.Id);
            var gameState = gameStates
                .OrderByDescending(gs => gs.Game?.Year ?? 0)
                .FirstOrDefault();


            return gameState?.Game;
        }
    }
}

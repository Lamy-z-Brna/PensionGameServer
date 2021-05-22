using PensionGame.Api.Data_Access.Connection;
using PensionGame.Api.Domain.Common;
using PensionGame.Api.Domain.Resources.Session;
using System.Linq;
using System.Threading.Tasks;

namespace PensionGame.Api.Data_Access.Readers.Session
{
    public class SessionInfoReader : ISessionInfoReader
    {
        private readonly GameStateDatabase _gameStateDatabase;
        private readonly ISessionReader _sessionReader;

        public SessionInfoReader(GameStateDatabase gameStateDatabase,
            ISessionReader sessionReader)
        {
            _gameStateDatabase = gameStateDatabase;
            _sessionReader = sessionReader;
        }

        public async Task<PaginatedCollection<SessionInfo>> GetAll(int page, int pageSize)
        {
            var sessions = await _sessionReader.GetAll(page, pageSize);

            var results = await _gameStateDatabase.GetAll(sessions.Items.Select(session => session.SessionId.Id));

            var gameStateBySessionId = results
                .Where(gameState => gameState != null && gameState.Game != null && gameState.Guid != null)
                .GroupBy(gameState => gameState.Guid!.Value)
                .ToDictionary(kv => kv.Key, g => g.OrderByDescending(gameState => gameState.Game!.Year).FirstOrDefault())
                .Where(kv => kv.Value != null)
                .ToDictionary(kv => kv.Key, kv => kv.Value!);

            var result = sessions
                .Items
                .Where(session => gameStateBySessionId.ContainsKey(session.SessionId.Id))
                .Select(session => 
                    {
                        var gameState = gameStateBySessionId[session.SessionId.Id]!.Game!;
                        return new SessionInfo(session, gameState.Year, gameState.IsFinished);
                    })
                .ToList();

            return new PaginatedCollection<SessionInfo>(result, sessions.CurrentPage, pageSize, sessions.TotalItems, sessions.TotalPages);
        }
    }
}

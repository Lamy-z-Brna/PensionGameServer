using PensionGame.Api.Domain.Resources.GameData;
using PensionGame.Api.Domain.Resources.Session;
using System.Threading.Tasks;

namespace PensionGame.Api.Data_Access.Readers.GameData
{
    public interface IGameStateReader : IReader
    {
        Task<GameState> Get(SessionId sessionId, int year);
        Task<GameState> Get(int gameStateId);
        Task<GameState> GetCurrentGameState(SessionId sessionId);
    }
}

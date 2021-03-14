using PensionGame.Api.Domain.Session;
using PensionGame.Api.Resources.GameData;
using System.Threading.Tasks;

namespace PensionGame.Api.Common.Readers.GameData
{
    public interface IGameStateReader : IReader
    {
        Task<GameState> Get(SessionId sessionId, int year);
    }
}

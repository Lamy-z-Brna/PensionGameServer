using PensionGame.DataAccess.Data_Objects.GameData;
using PensionGame.DataAccess.Data_Objects.Session;
using System.Threading.Tasks;

namespace PensionGame.DataAccess.Readers.GameData
{
    public interface IGameStateReader : IReader
    {
        Task<GameState> Get(SessionId sessionId, int year);
    }
}

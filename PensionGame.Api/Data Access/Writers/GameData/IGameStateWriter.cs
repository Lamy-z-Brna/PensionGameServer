using PensionGame.Api.Domain.Resources.Session;
using System.Threading.Tasks;

namespace PensionGame.Api.Data_Access.Writers.GameData
{
    public interface IGameStateWriter : IWriter
    {
        Task Create(SessionId sessionId, Domain.Resources.GameData.GameState gameState);
    }
}

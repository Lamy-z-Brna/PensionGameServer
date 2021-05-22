using PensionGame.Api.Domain.Resources.Session;
using PensionGame.Core.Domain.GameData;
using System.Threading.Tasks;

namespace PensionGame.Api.Data_Access.Writers.GameData
{
    public interface IGameStateWriter : IWriter
    {
        Task Create(SessionId sessionId, GameState gameState);
    }
}

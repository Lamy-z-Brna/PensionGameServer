using PensionGame.Api.Domain.Resources.GameData;
using PensionGame.Api.Domain.Resources.Session;
using PensionGame.Api.Handlers.Common;

namespace PensionGame.Api.Handlers.Queries
{
    public record GetGameStateQuery(SessionId SessionId) : IQuery<GameState?>
    {
    }
}

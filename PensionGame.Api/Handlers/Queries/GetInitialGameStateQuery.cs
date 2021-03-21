using PensionGame.Api.Domain.Resources.GameData;
using PensionGame.Api.Handlers.Common;

namespace PensionGame.Api.Handlers.Queries
{
    public record GetInitialGameStateQuery() : IQuery<GameState>
    {
    }
}

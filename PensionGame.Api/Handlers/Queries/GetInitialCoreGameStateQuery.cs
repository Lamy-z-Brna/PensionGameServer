using PensionGame.Api.Domain.Resources.Session;
using PensionGame.Api.Handlers.Common;
using PensionGame.Core.Domain.GameData;

namespace PensionGame.Api.Handlers.Queries
{
    public record GetInitialCoreGameStateQuery(StartupParameters? StartupParameters) : IQuery<GameState>
    {
    }
}

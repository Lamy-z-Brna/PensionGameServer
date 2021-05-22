using PensionGame.Api.Domain.Resources.ClientData;
using PensionGame.Api.Handlers.Common;
using PensionGame.Core.Domain.GameData;

namespace PensionGame.Api.Handlers.Queries
{
    public record GetNextGameStateQuery(GameState CurrentGameState, InvestmentSelection InvestmentSelection) : IQuery<GameState>
    {
    }
}

using PensionGame.Api.Domain.Resources.ClientData;
using PensionGame.Api.Domain.Resources.GameData;
using PensionGame.Api.Handlers.Common;

namespace PensionGame.Api.Handlers.Queries
{
    public record GetNextGameStateQuery(GameState CurrentGameState, InvestmentSelection InvestmentSelection) : IQuery<GameState>
    {
    }
}

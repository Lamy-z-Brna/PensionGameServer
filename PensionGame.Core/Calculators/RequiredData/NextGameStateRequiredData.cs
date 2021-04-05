using PensionGame.Core.Domain.ClientData;
using PensionGame.Core.Domain.GameData;
using PensionGame.Core.Domain.MarketData;

namespace PensionGame.Core.Calculators.RequiredData
{
    public record NextGameStateRequiredData(GameState PreviousGameState, InvestmentSelection InvestmentSelection)
    {
    }
}

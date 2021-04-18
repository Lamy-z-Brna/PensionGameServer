using PensionGame.Core.Domain.ClientData;
using PensionGame.Core.Domain.GameData;

namespace PensionGame.Core.Calculators.RequiredData
{
    public record NextGameStateRequiredData(Domain.GameData.GameState PreviousGameState, InvestmentSelection InvestmentSelection)
    {
    }
}

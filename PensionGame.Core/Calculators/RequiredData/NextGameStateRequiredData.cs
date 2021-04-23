using PensionGame.Core.Domain.ClientData;

namespace PensionGame.Core.Calculators.RequiredData
{
    public record NextGameStateRequiredData(Domain.GameData.GameState PreviousGameState, InvestmentSelection InvestmentSelection)
    {
    }
}

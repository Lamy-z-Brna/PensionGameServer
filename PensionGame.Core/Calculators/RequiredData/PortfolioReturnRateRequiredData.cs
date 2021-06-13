using System.Collections.Generic;

namespace PensionGame.Core.Calculators.RequiredData
{
    public record PortfolioReturnRateRequiredData(Dictionary<int, Domain.GameData.GameState> GameStates)
    {
    }
}

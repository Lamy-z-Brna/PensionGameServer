using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionGame.Core.Calculators.RequiredData
{
    public record AverageInflationRateRequiredData(IReadOnlyCollection<Domain.GameData.GameState> GameStates)
    {
    }
}

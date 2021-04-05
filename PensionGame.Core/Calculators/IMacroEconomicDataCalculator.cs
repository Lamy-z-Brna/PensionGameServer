using PensionGame.Core.Calculators.Common;
using PensionGame.Core.Calculators.RequiredData;
using PensionGame.Core.Domain.MarketData;

namespace PensionGame.Core.Calculators
{
    public interface IMacroEconomicDataCalculator : ICalculator<MacroEconomicDataRequiredData, MacroEconomicData>
    {
    }
}

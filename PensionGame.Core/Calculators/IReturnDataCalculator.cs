using PensionGame.Core.Calculators.Common;
using PensionGame.Core.Domain.MarketData;

namespace PensionGame.Core.Calculators
{
    public interface IReturnDataCalculator : ICalculator<MacroEconomicData, ReturnData>
    {
    }
}

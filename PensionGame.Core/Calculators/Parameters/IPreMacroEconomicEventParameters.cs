using PensionGame.Core.Calculators.Common;

namespace PensionGame.Core.Calculators.Parameters
{
    public interface IPreMacroEconomicEventParameters : ICalculatorParameters
    {
        double CrisisProbability { get; }
    }
}

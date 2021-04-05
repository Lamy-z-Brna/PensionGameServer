using PensionGame.Core.Calculators.Common;

namespace PensionGame.Core.Calculators.Parameters
{
    public interface IMacroEconomicDataParameters : ICalculatorParameters
    {
        double InflationRateMean { get; }
        double InflationRateDeviation { get; }

        double UnemploymentRateCrisisMean { get; }
        double UnemploymentRateNonCrisisMean { get; }
        double UnemploymentRateDeviation { get; }

        double InterestRateCrisisMean { get; }
        double InterestRateNonCrisisMean { get; }
        double InterestRateDeviation { get; }
    }
}

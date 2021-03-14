namespace PensionGame.Core.Calculators.Common
{
    public interface IMacroEconomicDataParameters : ICalculatorParameters
    {
        double CrisisProbability { get; }

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

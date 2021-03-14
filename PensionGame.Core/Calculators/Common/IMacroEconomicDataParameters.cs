namespace PensionGame.Core.Calculators.Common
{
    public interface IMacroEconomicDataParameters
    {
        double CrisisProbability { get; }

        double InflationRateMean { get; }
        double InflationRateDeviation { get; }

        double UnemploymentRateCrisisMean { get; }
        double UnemploymentRateNonCrisisMean { get; }
        double UnemploymentRateDeviation { get; }

        double InterestRateMean { get; }
        double InterestRateDeviation { get; }
    }
}

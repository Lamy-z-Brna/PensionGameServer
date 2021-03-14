namespace PensionGame.Core.Calculators.Common
{
    public class MacroEconomicDataParameters : IMacroEconomicDataParameters
    {
        public double CrisisProbability { get; } = 0.05;

        public double InflationRateMean { get; } = 0.02;
        public double InflationRateDeviation { get; } = 0.015;

        public double UnemploymentRateCrisisMean { get; } = 0.07;
        public double UnemploymentRateNonCrisisMean { get; } = 0.15;
        public double UnemploymentRateDeviation { get; } = 0.05;

        public double InterestRateMean { get; } = 0.012;
        public double InterestRateDeviation { get; } = 0.01;
    }
}

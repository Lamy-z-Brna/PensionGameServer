namespace PensionGame.Core.Calculators.Common
{
    public class ReturnDataParameters : IReturnDataParameters
    {
        public double StockRateToInterestRateRatio { get; } = 5.0;
        public double StockRateDeviation { get; } = 0.05;

        public double BondRateToInterestRateRatio { get; } = 3.0;
        public double BondRateDeviation { get; } = 0.02;

        public double BondDefaultRateCrisisMean { get; } = 0.05;
        public double BondDefaultRateNonCrisisMean { get; } = 0.005;
        public double BondDefaultRateDeviation { get; } = 0.005;

        public double LoanRateCrisisRiskRate { get; } = 0.1;
        public double LoanRateNonCrisisRiskRate { get; } = 0.2;
        public double LoanRateDeviation { get; } = 0.04;

    }
}

using PensionGame.Core.Calculators.Common;

namespace PensionGame.Core.Calculators.Parameters
{
    public interface IReturnDataParameters : ICalculatorParameters
    {
        double StockRateToInterestRateRatio { get; }
        double StockRateDeviation { get; }

        double BondRateToInterestRateRatio { get; }
        double BondRateDeviation { get; }

        double BondDefaultRateCrisisMean { get; }
        double BondDefaultRateNonCrisisMean { get; }
        double BondDefaultRateDeviation { get; }

        double LoanRateCrisisRiskRate { get; }
        double LoanRateNonCrisisRiskRate { get; }
        double LoanRateDeviation { get; }
    }
}

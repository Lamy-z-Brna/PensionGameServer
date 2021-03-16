using PensionGame.Core.Calculators.Parameters;
using PensionGame.Core.Common;
using PensionGame.Core.Domain;
using System;
using System.Linq;

namespace PensionGame.Core.Calculators
{
    //TODO VB unit tests?
    public class ReturnDataCalculator : IReturnDataCalculator
    {
        private readonly IRandomSampler _random;
        private readonly IReturnDataParameters _parameters;

        public ReturnDataCalculator(IRandomSampler random, IReturnDataParameters returnDataParameters)
        {
            _random = random;
            _parameters = returnDataParameters;
        }

        public ReturnData Calculate(MacroEconomicData macroEconomicData)
        {
            var stockRate = _random.GenerateNormal(
                _parameters.StockRateToInterestRateRatio * macroEconomicData.InterestRate,
                _parameters.StockRateDeviation).First();

            var bondRate = _random.GenerateNormal(
                _parameters.BondRateToInterestRateRatio * macroEconomicData.InterestRate,
                _parameters.BondRateDeviation).First();

            var bondDefaultRate = Math.Max(0.0,
                _random.GenerateNormal(
                    macroEconomicData.IsCrisis ? _parameters.BondDefaultRateCrisisMean : _parameters.BondDefaultRateNonCrisisMean,
                    _parameters.BondDefaultRateDeviation).First());

            var savingsAccountRate = macroEconomicData.InterestRate;

            var loanRateRiskRate = macroEconomicData.IsCrisis ? _parameters.LoanRateCrisisRiskRate : _parameters.LoanRateNonCrisisRiskRate;
            var loanRateMean = macroEconomicData.InterestRate + loanRateRiskRate;
            var loanRate = _random.GenerateNormal(loanRateMean, _parameters.LoanRateDeviation).First();

            return new ReturnData(stockRate, bondRate, bondDefaultRate, savingsAccountRate, loanRate);
        }
    }
}

using PensionGame.Core.Calculators.Parameters;
using PensionGame.Core.Calculators.RequiredData;
using PensionGame.Core.Common;
using PensionGame.Core.Domain.MarketData;
using PensionGame.Core.Events.Common;
using PensionGame.Core.Events.PreMacroEconomicEvents;
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

        public ReturnData Calculate(ReturnDataRequiredData requiredData)
        {
            var (macroEconomicData, events) = requiredData;
            var isCrisis = events.AnyEvent<CrisisEvent>();

            var stockRate = _random.GenerateNormal(
                _parameters.StockRateToInterestRateRatio * macroEconomicData.InterestRate,
                _parameters.StockRateDeviation)
                .First()
                .ToRound();

            var bondRate = _random.GenerateNormal(
                _parameters.BondRateToInterestRateRatio * macroEconomicData.InterestRate,
                _parameters.BondRateDeviation)
                .First()
                .ToRound();

            var bondDefaultRate = Math.Max(0.0,
                _random.GenerateNormal(
                    isCrisis ? _parameters.BondDefaultRateCrisisMean : _parameters.BondDefaultRateNonCrisisMean,
                    _parameters.BondDefaultRateDeviation).First());

            var savingsAccountRate = macroEconomicData.InterestRate;

            var loanRateRiskRate = isCrisis ? _parameters.LoanRateCrisisRiskRate : _parameters.LoanRateNonCrisisRiskRate;
            var loanRateMean = macroEconomicData.InterestRate + loanRateRiskRate;
            var loanRate = _random.GenerateNormal(loanRateMean, _parameters.LoanRateDeviation)
                .First()
                .ToRound();

            return new ReturnData(stockRate, bondRate, bondDefaultRate, savingsAccountRate, loanRate);
        }
    }
}

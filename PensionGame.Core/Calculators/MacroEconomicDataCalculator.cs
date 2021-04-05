using PensionGame.Core.Calculators.Parameters;
using PensionGame.Core.Calculators.RequiredData;
using PensionGame.Core.Common;
using PensionGame.Core.Domain.MarketData;
using PensionGame.Core.Events.PreMacroEconomicEvents;
using System;
using System.Linq;

namespace PensionGame.Core.Calculators
{
    //TODO VB unit tests?
    public class MacroEconomicDataCalculator : IMacroEconomicDataCalculator
    {
        private readonly IRandomSampler _random;
        private readonly IMacroEconomicDataParameters _parameters;

        public MacroEconomicDataCalculator(IRandomSampler random, IMacroEconomicDataParameters macroEconomicDataParameters)
        {
            _random = random;
            _parameters = macroEconomicDataParameters;
        }

        public MacroEconomicData Calculate(MacroEconomicDataRequiredData macroEconomicDataRequiredData)
        {
            var isCrisis = macroEconomicDataRequiredData.Events.Any(@event => @event is CrisisEvent);

            var inflationRate = _random.GenerateNormal(_parameters.InflationRateMean, _parameters.InflationRateDeviation)
                .First()
                .ToRound();

            var interestRate = _random.GenerateNormal(
                isCrisis ? _parameters.InterestRateCrisisMean : _parameters.InterestRateNonCrisisMean,
                _parameters.InterestRateDeviation)
                .First()
                .ToRound();

            var unemploymentRate = Math.Max(0.0,
                _random.GenerateNormal(
                    isCrisis ? _parameters.UnemploymentRateCrisisMean : _parameters.UnemploymentRateNonCrisisMean,
                    _parameters.UnemploymentRateDeviation).First())
                .ToRound();

            return new MacroEconomicData(inflationRate, unemploymentRate, interestRate);
        }
    }
}

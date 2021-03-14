using PensionGame.Core.Calculators.Common;
using PensionGame.Core.Common;
using PensionGame.Core.Domain;
using System;
using System.Linq;

namespace PensionGame.Core.Calculators
{
    public class MacroEconomicDataCalculator : IMacroEconomicDataCalculator
    {
        private readonly IRandomSampler _random;
        private readonly IMacroEconomicDataParameters _parameters;

        public MacroEconomicDataCalculator(IRandomSampler random, IMacroEconomicDataParameters macroEconomicDataParameters)
        {
            _random = random;
            _parameters = macroEconomicDataParameters;
        }

        public MacroEconomicData Calculate()
        {
            var isCrisis = _random.GenerateBernoulli(_parameters.CrisisProbability).First();
            var inflationRate = _random.GenerateNormal(_parameters.InflationRateMean, _parameters.InflationRateDeviation).First();
            var interestRate = _random.GenerateNormal(_parameters.InterestRateMean, _parameters.InterestRateDeviation).First();

            var unemploymentRate = Math.Max(0.0,
                _random.GenerateNormal(
                    isCrisis ? _parameters.UnemploymentRateCrisisMean : _parameters.UnemploymentRateNonCrisisMean,
                    _parameters.UnemploymentRateDeviation).First());

            return new MacroEconomicData(isCrisis, inflationRate, unemploymentRate, interestRate);
        }
    }
}

using PensionGame.Core.Calculators.Parameters;
using PensionGame.Core.Common;
using PensionGame.Core.Domain.MarketData;
using PensionGame.Core.Events;
using PensionGame.Core.Events.PreClientDataEvents;
using System.Collections.Generic;
using System.Linq;

namespace PensionGame.Core.Calculators.Events
{
    public sealed class PreClientDataEventCalculator : IPreClientDataEventCalculator
    {
        private readonly IRandomSampler _random;
        private readonly IPreClientDataEventParameters _preClientDataEventParameters;

        public PreClientDataEventCalculator(IRandomSampler random, 
            IPreClientDataEventParameters preClientDataEventParameters)
        {
            _random = random;
            _preClientDataEventParameters = preClientDataEventParameters;
        }

        public IReadOnlyCollection<PreClientDataEvent> Calculate(MacroEconomicData macroEconomicData)
        {
            var result = CalculateInternally(macroEconomicData).ToList();
            return result;
        }

        private IEnumerable<PreClientDataEvent> CalculateInternally(MacroEconomicData macroEconomicData)
        {
            var isUnemployed = _random.GenerateBernoulli(macroEconomicData.UnemploymentRate)
                .First();

            if (isUnemployed)
                yield return new UnemploymentEvent(_preClientDataEventParameters.UnemploymentIncomeLoss);
        }
    }
}

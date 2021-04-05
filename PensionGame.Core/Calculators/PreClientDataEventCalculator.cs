using PensionGame.Core.Calculators.Parameters;
using PensionGame.Core.Common;
using PensionGame.Core.Domain.MarketData;
using PensionGame.Core.Events;
using PensionGame.Core.Events.PreClientDataEvents;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PensionGame.Core.Calculators
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

        public IEnumerable<IPreClientDataEvent> Calculate(MacroEconomicData macroEconomicData)
        {
            var isUnemployed = _random.GenerateBernoulli(macroEconomicData.UnemploymentRate)
                .First();

            if (isUnemployed)
                yield return new UnemploymentEvent(_preClientDataEventParameters.UnemploymentIncomeLoss);
        }
    }
}

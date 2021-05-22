using PensionGame.Core.Calculators.Parameters;
using PensionGame.Core.Common;
using PensionGame.Core.Events.PreMacroEconomicEvents;
using System.Collections.Generic;
using System.Linq;

namespace PensionGame.Core.Calculators.Events
{
    public sealed class PreMacroEconomicEventCalculator : IPreMacroEconomicEventCalculator
    {
        private readonly IRandomSampler _random;
        private readonly IPreMacroEconomicEventParameters _parameters;

        public PreMacroEconomicEventCalculator(IRandomSampler random, IPreMacroEconomicEventParameters parameters)
        {
            _random = random;
            _parameters = parameters;
        }        

        public IReadOnlyCollection<PreMacroEconomicEvent> Calculate()
        {
            var result = GenerateInternally().ToList();
            return result;
        }

        private IEnumerable<PreMacroEconomicEvent> GenerateInternally()
        {
            var isCrisis = _random.GenerateBernoulli(_parameters.CrisisProbability)
                .First();

            if (isCrisis)
                yield return new CrisisEvent();
        }
    }
}

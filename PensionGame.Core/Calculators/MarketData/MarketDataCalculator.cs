using PensionGame.Core.Calculators.Events;
using PensionGame.Core.Calculators.RequiredData;
using PensionGame.Core.Events.PreClientDataEvents;
using System.Collections.Generic;
using System.Linq;

namespace PensionGame.Core.Calculators.MarketData
{
    public sealed class MarketDataCalculator : IMarketDataCalculator
    {
        private readonly IPreMacroEconomicEventCalculator _preMacroEconomicEventGenerator;
        private readonly IMacroEconomicDataCalculator _macroEconomicDataCalculator;
        private readonly IPreReturnsEventCalculator _preReturnsEventGenerator;
        private readonly IReturnDataCalculator _returnDataCalculator;

        public MarketDataCalculator(IMacroEconomicDataCalculator macroEconomicDataCalculator,
            IReturnDataCalculator returnDataCalculator,
            IPreMacroEconomicEventCalculator preMacroEconomicEventGenerator, 
            IPreReturnsEventCalculator preReturnsEventCalculator)
        {
            _macroEconomicDataCalculator = macroEconomicDataCalculator;
            _returnDataCalculator = returnDataCalculator;
            _preMacroEconomicEventGenerator = preMacroEconomicEventGenerator;
            _preReturnsEventGenerator = preReturnsEventCalculator;
        }

        public (Domain.MarketData.MarketData, IReadOnlyCollection<PreClientDataEvent>) Calculate()
        {
            var preMacroEconomicEvents = _preMacroEconomicEventGenerator.Calculate();

            var newMacroEconomicData = _macroEconomicDataCalculator.Calculate(new MacroEconomicDataRequiredData(preMacroEconomicEvents));

            var preReturnsEvents = _preReturnsEventGenerator
                .Calculate()
                .Union(preMacroEconomicEvents)
                .ToList();           

            var newReturnData = _returnDataCalculator.Calculate(new ReturnDataRequiredData(newMacroEconomicData, preReturnsEvents));

            return (new (newMacroEconomicData, newReturnData), preReturnsEvents);
        }
    }
}

using PensionGame.Core.Calculators.RequiredData;
using PensionGame.Core.Domain.MarketData;
using PensionGame.Core.Events.PreClientDataEvents;
using System.Collections.Generic;
using System.Linq;

namespace PensionGame.Core.Calculators
{
    public sealed class MarketDataGenerator : IMarketDataGenerator
    {
        private readonly IPreMacroEconomicEventGenerator _preMacroEconomicEventGenerator;
        private readonly IMacroEconomicDataCalculator _macroEconomicDataCalculator;
        private readonly IPreReturnsEventGenerator _preReturnsEventGenerator;
        private readonly IReturnDataCalculator _returnDataCalculator;

        public MarketDataGenerator(IMacroEconomicDataCalculator macroEconomicDataCalculator,
            IReturnDataCalculator returnDataCalculator,
            IPreMacroEconomicEventGenerator preMacroEconomicEventGenerator, 
            IPreReturnsEventGenerator preReturnsEventCalculator)
        {
            _macroEconomicDataCalculator = macroEconomicDataCalculator;
            _returnDataCalculator = returnDataCalculator;
            _preMacroEconomicEventGenerator = preMacroEconomicEventGenerator;
            _preReturnsEventGenerator = preReturnsEventCalculator;
        }

        public (MarketData, IReadOnlyCollection<IPreClientDataEvent>) Generate()
        {
            var preMacroEconomicEvents = _preMacroEconomicEventGenerator.Generate().ToList();

            var newMacroEconomicData = _macroEconomicDataCalculator.Calculate(new MacroEconomicDataRequiredData(preMacroEconomicEvents));

            var preReturnsEvents = _preReturnsEventGenerator
                .Generate()
                .Union(preMacroEconomicEvents)
                .ToList();           

            var newReturnData = _returnDataCalculator.Calculate(new ReturnDataRequiredData(newMacroEconomicData, preReturnsEvents));

            return (new MarketData(newMacroEconomicData, newReturnData), preReturnsEvents);
        }
    }
}

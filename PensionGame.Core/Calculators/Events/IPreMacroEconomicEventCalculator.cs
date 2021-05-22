using PensionGame.Core.Calculators.Common;
using PensionGame.Core.Events.PreMacroEconomicEvents;
using System.Collections.Generic;

namespace PensionGame.Core.Calculators.Events
{
    public interface IPreMacroEconomicEventCalculator : ICalculator<IReadOnlyCollection<PreMacroEconomicEvent>>
    {
    }
}

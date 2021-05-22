using PensionGame.Core.Events.PreMacroEconomicEvents;
using System.Collections.Generic;

namespace PensionGame.Core.Calculators.RequiredData
{
    public record MacroEconomicDataRequiredData(IReadOnlyCollection<PreMacroEconomicEvent> Events)
    {
    }
}

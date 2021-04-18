using PensionGame.Core.Domain.MarketData;
using PensionGame.Core.Events.PreReturnsEvents;
using System.Collections.Generic;

namespace PensionGame.Core.Calculators.RequiredData
{
    public record ReturnDataRequiredData(MacroEconomicData MacroEconomicData, IReadOnlyCollection<IPreReturnsEvent> Events)
    {
    }
}

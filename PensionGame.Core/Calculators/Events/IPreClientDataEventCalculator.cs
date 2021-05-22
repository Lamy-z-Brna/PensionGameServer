using PensionGame.Core.Calculators.Common;
using PensionGame.Core.Domain.MarketData;
using PensionGame.Core.Events.PreClientDataEvents;
using System.Collections.Generic;

namespace PensionGame.Core.Calculators.Events
{
    public interface IPreClientDataEventCalculator : ICalculator<MacroEconomicData, IReadOnlyCollection<PreClientDataEvent>>
    {
    }
}

using PensionGame.Core.Calculators.Common;
using PensionGame.Core.Domain.MarketData;
using PensionGame.Core.Events.PreClientDataEvents;
using System.Collections.Generic;

namespace PensionGame.Core.Calculators
{
    public interface IMarketDataGenerator : IGenerator<(MarketData, IReadOnlyCollection<IPreClientDataEvent>)>
    {
    }
}

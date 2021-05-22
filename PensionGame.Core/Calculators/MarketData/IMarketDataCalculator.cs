using PensionGame.Core.Calculators.Common;
using PensionGame.Core.Events.PreClientDataEvents;
using System.Collections.Generic;

namespace PensionGame.Core.Calculators.MarketData
{
    public interface IMarketDataCalculator : ICalculator<(Domain.MarketData.MarketData, IReadOnlyCollection<PreClientDataEvent>)>
    {
    }
}

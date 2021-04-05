using PensionGame.Core.Domain.ClientData;
using PensionGame.Core.Domain.MarketData;
using PensionGame.Core.Events.PreClientDataEvents;
using System.Collections.Generic;

namespace PensionGame.Core.Calculators.RequiredData
{
    public record ClientDataRequiredData(ClientData PreviousClientData, MarketData PreviousMarketData, InvestmentSelection InvestmentSelection, MarketData MarketData, IEnumerable<IPreClientDataEvent> Events)
    {
    }
}

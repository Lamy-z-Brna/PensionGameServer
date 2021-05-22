using PensionGame.Core.Domain.ClientData;
using PensionGame.Core.Events.PreClientDataEvents;
using System.Collections.Generic;

namespace PensionGame.Core.Calculators.RequiredData
{
    public record ClientDataRequiredData(Domain.ClientData.ClientData PreviousClientData, Domain.MarketData.MarketData PreviousMarketData, InvestmentSelection InvestmentSelection, Domain.MarketData.MarketData MarketData, IReadOnlyCollection<PreClientDataEvent> Events)
    {
    }
}

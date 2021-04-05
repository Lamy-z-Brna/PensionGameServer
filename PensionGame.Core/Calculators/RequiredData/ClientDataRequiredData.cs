using PensionGame.Core.Domain.ClientData;
using PensionGame.Core.Domain.MarketData;
using PensionGame.Core.Events.Common;
using System.Collections.Generic;

namespace PensionGame.Core.Calculators.RequiredData
{
    public record ClientDataRequiredData(ClientData PreviousClientData, MarketData PreviousMarketData, InvestmentSelection InvestmentSelection, MacroEconomicData MacroEconomicData, ReturnData ReturnData, IEnumerable<IEvent> Events)
    {
    }
}

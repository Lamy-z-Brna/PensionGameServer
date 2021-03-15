using PensionGame.Core.Domain;
using PensionGame.Core.Domain.ClientData;
using PensionGame.Core.Events.Common;
using System.Collections.Generic;

namespace PensionGame.Core.Calculators.RequiredData
{
    public record ClientDataRequiredData(ClientData PreviousClientData, InvestmentSelection InvestmentSelection, MacroEconomicData MacroEconomicData, ReturnData ReturnData, IEnumerable<IEvent> Events)
    {
    }
}

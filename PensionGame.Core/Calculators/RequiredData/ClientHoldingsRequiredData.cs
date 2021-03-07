using PensionGame.Core.Domain;
using PensionGame.Core.Domain.ClientData;
using PensionGame.Core.Domain.Holdings;
using PensionGame.Core.Events.Common;
using System.Collections.Generic;

namespace PensionGame.Core.Calculators.RequiredData
{
    public record ClientHoldingsRequiredData(ClientHoldings PreviousClientHoldings, InvestmentSelection InvestmentSelection, ReturnData ReturnData, IEnumerable<IEvent> Events)
    {
    }
}

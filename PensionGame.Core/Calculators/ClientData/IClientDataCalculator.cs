using PensionGame.Core.Calculators.Common;
using PensionGame.Core.Calculators.RequiredData;
using PensionGame.Core.Events.Common;
using System.Collections.Generic;

namespace PensionGame.Core.Calculators.ClientData
{
    public interface IClientDataCalculator : ICalculator<ClientDataRequiredData, (Domain.ClientData.ClientData, IReadOnlyCollection<Event>)>
    {
    }
}

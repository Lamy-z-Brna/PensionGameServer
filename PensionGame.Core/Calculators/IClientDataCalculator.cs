using PensionGame.Core.Calculators.Common;
using PensionGame.Core.Calculators.RequiredData;
using PensionGame.Core.Domain.ClientData;
using PensionGame.Core.Events.Common;
using System.Collections.Generic;

namespace PensionGame.Core.Calculators
{
    public interface IClientDataCalculator : ICalculator<ClientDataRequiredData, (ClientData, IReadOnlyCollection<IEvent>)>
    {
    }
}

using PensionGame.Core.Calculators.Common;
using PensionGame.Core.Calculators.RequiredData;
using PensionGame.Core.Domain.Holdings;
using PensionGame.Core.Events.Common;
using System.Collections.Generic;

namespace PensionGame.Core.Calculators.Holdings
{
    public interface INewBondCalculator : ICalculator<NewBondRequiredData, (BondHoldings, IReadOnlyCollection<Event>)>
    {
    }
}

using PensionGame.Core.Calculators.Common;
using PensionGame.Core.Calculators.RequiredData;
using PensionGame.Core.Domain.Holdings;
using PensionGame.Core.Events.Common;
using System.Collections.Generic;

namespace PensionGame.Core.Calculators
{
    public interface INewSavingsAccountCalculator : ICalculator<NewSavingsAccountRequiredData, (SavingsAccountHoldings SavingsAccountHoldings, IReadOnlyCollection<IEvent> Events)>
    {
    }
}

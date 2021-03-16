using PensionGame.Core.Calculators.Common;
using PensionGame.Core.Calculators.RequiredData;
using PensionGame.Core.Domain.ClientData;

namespace PensionGame.Core.Calculators.Validation
{
    public interface IInvestmentSelectionValidationCalculator : IValidationCalculator<InvestmentSelectionValidationRequiredData, InvestmentSelection>
    {
    }
}

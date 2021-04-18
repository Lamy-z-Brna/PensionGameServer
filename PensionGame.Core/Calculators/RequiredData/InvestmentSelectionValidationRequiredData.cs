using PensionGame.Core.Domain.ClientData;

namespace PensionGame.Core.Calculators.RequiredData
{
    public record InvestmentSelectionValidationRequiredData(Domain.ClientData.ClientData CurrentClientData, InvestmentSelection InvestmentSelection)
    {
    }
}

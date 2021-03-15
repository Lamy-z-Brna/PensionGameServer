using PensionGame.Core.Domain.ClientData;

namespace PensionGame.Core.Calculators.RequiredData
{
    public record InvestmentSelectionValidationRequiredData(ClientData CurrentClientData, InvestmentSelection InvestmentSelection)
    {
    }
}

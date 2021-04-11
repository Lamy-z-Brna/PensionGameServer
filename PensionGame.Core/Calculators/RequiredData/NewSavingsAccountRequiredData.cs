using PensionGame.Core.Domain.ClientData;

namespace PensionGame.Core.Calculators.RequiredData
{
    public record NewSavingsAccountRequiredData(ClientData CurrentClientData, InvestmentSelection InvestmentSelection)
    {
    }
}

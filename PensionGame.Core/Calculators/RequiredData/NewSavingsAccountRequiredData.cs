using PensionGame.Core.Domain.ClientData;

namespace PensionGame.Core.Calculators.RequiredData
{
    public record NewSavingsAccountRequiredData(Domain.ClientData.ClientData CurrentClientData, InvestmentSelection InvestmentSelection)
    {
    }
}

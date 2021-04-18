using PensionGame.Core.Domain.ClientData;

namespace PensionGame.Core.Calculators.RequiredData
{
    public record AvailableToInvestRequiredData(Domain.ClientData.ClientData CurrentClientData, InvestmentSelection InvestmentSelection)
    {
    }
}

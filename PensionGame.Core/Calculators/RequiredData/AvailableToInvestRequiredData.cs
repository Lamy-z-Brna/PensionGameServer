using PensionGame.Core.Domain.ClientData;

namespace PensionGame.Core.Calculators.RequiredData
{
    public record AvailableToInvestRequiredData(ClientData CurrentClientData, InvestmentSelection InvestmentSelection)
    {
    }
}

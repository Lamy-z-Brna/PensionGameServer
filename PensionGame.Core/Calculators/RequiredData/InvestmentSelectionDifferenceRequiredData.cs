using PensionGame.Core.Domain.ClientData;
using PensionGame.Core.Domain.Holdings;

namespace PensionGame.Core.Calculators.RequiredData
{
    public record InvestmentSelectionDifferenceRequiredData(ClientHoldings CurrentHoldings, InvestmentSelection InvestmentSelection)
    {
    }
}

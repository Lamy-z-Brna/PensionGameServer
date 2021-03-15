using PensionGame.Core.Domain.ClientData;
using PensionGame.Core.Domain.Holdings;

namespace PensionGame.Core.Calculators.RequiredData
{
    public record NewBondRequiredData(BondHoldings CurrentBonds, InvestmentSelection InvestmentSelection, double BondInterestRate, double BondDefaultRate)
    {
    }
}

using System.Collections.Generic;

namespace PensionGame.Api.Domain.Resources.Holdings
{
    public record ClientHoldings(StockHolding Stocks, IEnumerable<BondHolding> Bonds, SavingsAccountHoldings SavingsAccount, IEnumerable<LoanHolding> Loans)
    {
    }
}

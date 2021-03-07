using System.Collections.Generic;

namespace PensionGame.Core.Domain.Holdings
{
    public record ClientHoldings(StockHolding Stocks, IEnumerable<BondHolding> Bonds, SavingsAccountHoldings SavingsAccount, IEnumerable<LoanHolding> Loans)
    {
    }
}

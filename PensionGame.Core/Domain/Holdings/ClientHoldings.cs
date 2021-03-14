using System.Collections.Generic;
using System.Linq;

namespace PensionGame.Core.Domain.Holdings
{
    public record ClientHoldings(StockHolding Stocks, IEnumerable<BondHolding> Bonds, SavingsAccountHoldings SavingsAccount, IEnumerable<LoanHolding> Loans)
    {
        public int TotalLoanValue => Loans.Sum(loan => loan.Amount);
    }
}

using System.Linq;

namespace PensionGame.Core.Domain.Holdings
{
    public record ClientHoldings(StockHolding Stocks, BondHoldings Bonds, SavingsAccountHoldings SavingsAccount, LoanHoldings Loans)
    {
        public int TotalLoanValue => Loans.Sum(loan => loan.Amount);

        public int Value => Stocks.Value + Bonds.Value + SavingsAccount.Amount - Loans.TotalLoanValue;
    }
}

namespace PensionGame.Api.Domain.Resources.Holdings
{
    public record ClientHoldings(StockHolding Stocks, BondHoldings Bonds, SavingsAccountHoldings SavingsAccount, LoanHoldings Loans)
    {
        public int Value => Stocks.Value + Bonds.Value + SavingsAccount.Amount - Loans.TotalLoanValue;
    }
}

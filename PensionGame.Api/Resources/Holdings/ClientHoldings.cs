namespace PensionGame.Api.Resources.Holdings
{
    public record ClientHoldings(StockHolding Stocks, BondHoldings Bonds, SavingsAccountHoldings SavingsAccount, LoanHoldings Loans)
    {
    }
}

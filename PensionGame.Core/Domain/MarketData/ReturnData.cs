namespace PensionGame.Core.Domain.MarketData
{
    public record ReturnData(double StockRate, double BondRate, double BondDefaultRate, double SavingsAccountRate, double LoanRate)
    {
    }
}

namespace PensionGame.Api.Domain.Resources.MarketData
{
    public record ReturnData(double StockRate, double BondRate, double BondDefaultRate, double SavingsAccountRate, double LoanRate)
    {
    }
}

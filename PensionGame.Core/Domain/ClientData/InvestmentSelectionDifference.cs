namespace PensionGame.Core.Domain.ClientData
{
    public record InvestmentSelectionDifference(int StockChange, int BondChange, int SavingsAccountChange, int LoanChange)
    {
    }
}

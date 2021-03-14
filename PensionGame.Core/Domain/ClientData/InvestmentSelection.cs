namespace PensionGame.Core.Domain.ClientData
{
    public record InvestmentSelection(int StockValue, int BondValue, int SavingsAccountValue, int LoanValue)
    {
        public int TotalInvestedValue => StockValue + BondValue + SavingsAccountValue;
    }
}

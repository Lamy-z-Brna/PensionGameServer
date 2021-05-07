namespace PensionGame.Api.Domain.Resources.ClientData
{
    public record InvestmentSelection(int StockValue, int BondValue, int SavingsAccountValue, int LoanValue)
    {
        public InvestmentSelection() : this(0, 0, 0, 0)
        {
        }
    }
}

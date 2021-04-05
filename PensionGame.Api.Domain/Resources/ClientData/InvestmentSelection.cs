namespace PensionGame.Api.Domain.Resources.ClientData
{
    public record InvestmentSelection
    {
        public int StockValue { get; init; }

        public int BondValue { get; init; }

        public int SavingsAccountValue { get; init; }

        public int LoanValue { get; init; }
    }
}

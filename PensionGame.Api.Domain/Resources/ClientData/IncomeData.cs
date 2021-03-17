namespace PensionGame.Api.Domain.Resources.ClientData
{
    public record IncomeData
    {
        public int Salary { get; init; }

        public int BondInterest { get; init; }

        public int SavingsAccountInterest { get; init; }

        public int ExtraIncome { get; init; }

        public int TotalIncome => Salary + BondInterest + SavingsAccountInterest + ExtraIncome;
    }
}

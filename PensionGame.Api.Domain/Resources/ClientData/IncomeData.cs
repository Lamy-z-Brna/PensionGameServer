namespace PensionGame.Api.Domain.Resources.ClientData
{
    public record IncomeData
    {
        public int ExpectedSalary { get; init; }

        public int ActualSalary { get; init; }

        public int BondInterest { get; init; }

        public int SavingsAccountInterest { get; init; }

        public int ExtraIncome { get; init; }

        public int TotalIncome => ActualSalary + BondInterest + SavingsAccountInterest + ExtraIncome;
    }
}

namespace PensionGame.Api.Domain.Resources.ClientData
{
    public record IncomeData(int ExpectedSalary, int ActualSalary, int BondInterest, int SavingsAccountInterest, int ExtraIncome)
    {
        public int TotalIncome => ActualSalary + BondInterest + SavingsAccountInterest + ExtraIncome;
    }
}

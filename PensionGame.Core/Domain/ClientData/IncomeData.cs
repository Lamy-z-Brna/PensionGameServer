namespace PensionGame.Core.Domain.ClientData
{
    public record IncomeData(int Salary, int BondInterest, int SavingsAccountInterest, int ExtraIncome)
    {
        public int TotalIncome => Salary + BondInterest + SavingsAccountInterest + ExtraIncome;
    }
}

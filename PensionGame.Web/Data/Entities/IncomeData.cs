using System;

namespace PensionGame.Web.Data.Entities
{
    public record IncomeData(int salary, int BondInterest, int SavingsAccountInterest, int ExtraIncome, int TotalIncome)
    {
    }
}
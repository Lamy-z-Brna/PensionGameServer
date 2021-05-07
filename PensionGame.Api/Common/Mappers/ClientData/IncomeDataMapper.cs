namespace PensionGame.Api.Common.Mappers.ClientData
{
    public sealed class IncomeDataMapper : IIncomeDataMapper
    {
        public Domain.Resources.ClientData.IncomeData Map(Core.Domain.ClientData.IncomeData incomeData)
        {
            return new(
                ExpectedSalary: incomeData.ExpectedSalary,
                ActualSalary: incomeData.ActualSalary,
                BondInterest: incomeData.BondInterest,
                SavingsAccountInterest: incomeData.SavingsAccountInterest,
                ExtraIncome: incomeData.ExtraIncome
                );
        }

        public Core.Domain.ClientData.IncomeData Map(Domain.Resources.ClientData.IncomeData incomeData)
        {
            return new(
                ExpectedSalary: incomeData.ExpectedSalary,
                ActualSalary: incomeData.ActualSalary,
                BondInterest: incomeData.BondInterest,
                SavingsAccountInterest: incomeData.SavingsAccountInterest,
                ExtraIncome: incomeData.ExtraIncome
                );
        }
    }
}

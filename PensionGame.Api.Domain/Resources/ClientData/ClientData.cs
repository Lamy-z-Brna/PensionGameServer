using PensionGame.Api.Domain.Resources.Holdings;

namespace PensionGame.Api.Domain.Resources.ClientData
{
    public record ClientData(IncomeData IncomeData, ExpenseData ExpenseData, ClientHoldings ClientHoldings)
    {
        public int DisposableIncome => IncomeData.TotalIncome - ExpenseData.TotalExpenses;

        public bool IsNegativeDisposableIncome => DisposableIncome < 0;
    }
}

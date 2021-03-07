using PensionGame.Core.Domain.Holdings;

namespace PensionGame.Core.Domain.ClientData
{
    public record ClientData(IncomeData IncomeData, ExpenseData ExpenseData, ClientHoldings ClientHoldings)
    {
        public int DisposableIncome => IncomeData.TotalIncome - ExpenseData.TotalExpenses;

        public bool IsNegativeDisposableIncome => DisposableIncome < 0;
    }
}

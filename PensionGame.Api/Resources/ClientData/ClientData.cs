using PensionGame.Api.Resources.Events;
using PensionGame.Api.Resources.Holdings;
using System.Collections.Generic;

namespace PensionGame.Api.Resources.ClientData
{
    public record ClientData(IncomeData IncomeData, ExpenseData ExpenseData, ClientHoldings ClientHoldings, IEnumerable<Event> Events)
    {
        public int DisposableIncome => IncomeData.TotalIncome - ExpenseData.TotalExpenses;

        public bool IsNegativeDisposableIncome => DisposableIncome < 0;
    }
}

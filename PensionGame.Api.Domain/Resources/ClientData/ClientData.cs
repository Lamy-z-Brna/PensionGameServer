using PensionGame.Api.Domain.Resources.Events;
using PensionGame.Api.Domain.Resources.Holdings;
using System.Collections.Generic;

namespace PensionGame.Api.Domain.Resources.ClientData
{
    public record ClientData(IncomeData IncomeData, ExpenseData ExpenseData, ClientHoldings ClientHoldings, IEnumerable<Event> Events)
    {
        public int DisposableIncome => IncomeData.TotalIncome - ExpenseData.TotalExpenses;

        public bool IsNegativeDisposableIncome => DisposableIncome < 0;
    }
}

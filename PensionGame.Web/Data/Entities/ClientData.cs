using System;
using System.Collections.Generic;

namespace PensionGame.Web.Data.Entities
{
    public record ClientData(IncomeData IncomeData, ExpenseData ExpenseData, ClientHoldings ClientHoldings, IEnumerable<Event> Events, int DisposableIncome, bool IsNegativeDisposableIncome)
    {
    }
}
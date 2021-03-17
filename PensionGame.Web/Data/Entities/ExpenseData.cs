using System;

namespace PensionGame.Web.Data.Entities
{
    public record ExpenseData(int LifeExpenses, int Rent, int ChildrenExpenses, int ExtraExpenses, int TotalExpenses)
    {
    }
}
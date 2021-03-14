namespace PensionGame.Core.Domain.ClientData
{
    public record ExpenseData(int LifeExpenses, int LoanExpenses, int Rent, int ChildrenExpenses, int ExtraExpenses)
    {
        public int TotalExpenses => LifeExpenses + LoanExpenses + Rent + ChildrenExpenses + ExtraExpenses;
    }
}

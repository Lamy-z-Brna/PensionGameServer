namespace PensionGame.Core.Domain.ClientData
{
    public record ExpenseData(int LifeExpenses, int LoanInterest, int Rent, int ChildrenExpenses, int ExtraExpenses)
    {
        public int TotalExpenses => LifeExpenses + LoanInterest + Rent + ChildrenExpenses + ExtraExpenses;
    }
}

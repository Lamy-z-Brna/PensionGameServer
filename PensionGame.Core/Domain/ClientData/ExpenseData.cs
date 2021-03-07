namespace PensionGame.Core.Domain.ClientData
{
    public record ExpenseData(int LifeExpenses, int Rent, int ChildrenExpenses, int ExtraExpenses)
    {
        public int TotalExpenses => LifeExpenses + Rent + ChildrenExpenses + ExtraExpenses;
    }
}

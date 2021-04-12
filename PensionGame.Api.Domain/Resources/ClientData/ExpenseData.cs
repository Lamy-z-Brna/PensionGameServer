namespace PensionGame.Api.Domain.Resources.ClientData
{
    public record ExpenseData
    {
        public int LifeExpenses { get; init; }

        public int LoanExpenses { get; init; }

        public int Rent { get; init; }

        public int ChildrenExpenses { get; init; }

        public int ExtraExpenses { get; init; }

        public int TotalExpenses => LifeExpenses + LoanExpenses + Rent + ChildrenExpenses + ExtraExpenses;
    }
}

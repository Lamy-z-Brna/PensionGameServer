namespace PensionGame.Api.Common.Mappers.ClientData
{
    public sealed class ExpenseDataMapper : IExpenseDataMapper
    {
        public Domain.Resources.ClientData.ExpenseData Map(Core.Domain.ClientData.ExpenseData expenseData)
        {
            return new (
                LifeExpenses: expenseData.LifeExpenses,
                LoanExpenses: expenseData.LoanExpenses,
                Rent: expenseData.Rent,
                ChildrenExpenses: expenseData.ChildrenExpenses,
                ExtraExpenses: expenseData.ExtraExpenses
                );
        }

        public Core.Domain.ClientData.ExpenseData Map(Domain.Resources.ClientData.ExpenseData expenseData)
        {
            return new (
                LifeExpenses: expenseData.LifeExpenses,
                LoanExpenses: expenseData.LoanExpenses,
                Rent: expenseData.Rent,
                ChildrenExpenses: expenseData.ChildrenExpenses,
                ExtraExpenses: expenseData.ExtraExpenses
                );
        }
    }
}

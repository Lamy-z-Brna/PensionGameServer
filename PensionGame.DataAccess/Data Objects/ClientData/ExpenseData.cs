using System.ComponentModel.DataAnnotations.Schema;

namespace PensionGame.DataAccess.Data_Objects.ClientData
{
    public class ExpenseData
    {
        public int Id { get; set; }
        [ForeignKey("ClientData")]
        public int ClientDataId { get; set; }
        public int LifeExpenses { get; set; }
        public int LoanExpenses { get; set; }
        public int Rent { get; set; }
        public int ChildrenExpenses { get; set; }
        public int ExtraExpenses { get; set; }

        public ExpenseData(int lifeExpenses, int loanExpenses, int rent, int childrenExpenses, int extraExpenses)
        {
            LifeExpenses = lifeExpenses;
            LoanExpenses = loanExpenses;
            Rent = rent;
            ChildrenExpenses = childrenExpenses;
            ExtraExpenses = extraExpenses;
        }

        public ExpenseData() { }
    }
}

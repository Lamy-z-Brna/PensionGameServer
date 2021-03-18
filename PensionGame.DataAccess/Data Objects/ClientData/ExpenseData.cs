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
    }
}

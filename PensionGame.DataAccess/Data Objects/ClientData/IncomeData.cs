using System.ComponentModel.DataAnnotations.Schema;

namespace PensionGame.DataAccess.Data_Objects.ClientData
{
    public class IncomeData
    {
        public int Id { get; set; }
        [ForeignKey("ClientData")]
        public int ClientDataId { get; set; }
        public int Salary { get; set; }
        public int BondInterest { get; set; }
        public int SavingsAccountInterest { get; set; }
        public int ExtraIncome { get; set; }
    }
}

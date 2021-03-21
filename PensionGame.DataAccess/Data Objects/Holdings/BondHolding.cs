using System.ComponentModel.DataAnnotations.Schema;

namespace PensionGame.DataAccess.Data_Objects.Holdings
{
    public class BondHolding
    {
        public int Id { get; set; }
        [ForeignKey("ClientHoldings")]
        public int ClientHoldingId { get; set; }
        public int YearlyPayment { get; set; }
        public int YearsToExpiration { get; set; }
        public ClientHoldings? ClientHoldings { get; set; }

        public BondHolding(int yearlyPayment, int yearsToExpiration)
        {
            YearlyPayment = yearlyPayment;
            YearsToExpiration = yearsToExpiration;
        }
    }
}

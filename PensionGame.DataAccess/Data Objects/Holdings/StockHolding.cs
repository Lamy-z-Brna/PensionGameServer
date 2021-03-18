using System.ComponentModel.DataAnnotations.Schema;

namespace PensionGame.DataAccess.Data_Objects.Holdings
{
    public class StockHolding
    {
        public int Id { get; set; }
        [ForeignKey("ClientHoldings")]
        public int ClientHoldingId { get; set; }
        public double UnitPrice { get; set; }
        public double UnitsHeld { get; set; }
        public ClientHoldings? ClientHoldings { get; set; }
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace PensionGame.DataAccess.Data_Objects.Holdings
{
    public class ClientHoldings
    {
        public int Id { get; set; }
        [ForeignKey("ClientData")]
        public int ClientDataId { get; set; }
        public IEnumerable<BondHolding>? Bonds { get; set; }
        public IEnumerable<LoanHolding>? Loans { get; set; }
        public SavingsAccountHolding? SavingsAccount { get; set; }
        public StockHolding? Stocks { get; set; }
        public ClientData.ClientData? ClientData { get; set; }

        public ClientHoldings(IEnumerable<BondHolding> bonds, IEnumerable<LoanHolding> loans, SavingsAccountHolding savingsAccount, StockHolding stocks)
        {
            Bonds = bonds;
            Loans = loans;
            SavingsAccount = savingsAccount;
            Stocks = stocks;
        }

        public ClientHoldings()
        {
        }
    }
}

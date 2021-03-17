using System;

namespace PensionGame.Web.Data.Entities
{
    public class GameUpdate
    {
        public int StockValue { get; set; }

        public int BondValue { get; set; }

        public int SavingsAccountValue { get; set; }

        public int LoanValue { get; set; }
    }
}
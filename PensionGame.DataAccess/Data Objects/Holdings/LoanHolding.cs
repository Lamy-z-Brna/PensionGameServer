﻿using System.ComponentModel.DataAnnotations.Schema;

namespace PensionGame.DataAccess.Data_Objects.Holdings
{
    public class LoanHolding
    {
        public int Id { get; set; }
        [ForeignKey("ClientHoldings")]
        public int ClientHoldingId { get; set; }
        public int Amount { get; set; }
        public double InterestRate { get; set; }
        public ClientHoldings? ClientHoldings { get; set; }
    }
}

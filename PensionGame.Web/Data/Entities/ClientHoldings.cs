using System;
using System.Collections.Generic;

namespace PensionGame.Web.Data.Entities
{
    public record ClientHoldings(StockHolding Stocks, IEnumerable<BondHolding> Bonds, SavingsAccountHoldings SavingsAccount, IEnumerable<LoanHolding> Loans)
    {
    }
}
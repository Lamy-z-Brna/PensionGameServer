using PensionGame.Core.Domain.Holdings;
using System.Collections.Generic;

namespace PensionGame.Core.Common
{
    public static class EnumerableExtensions
    {
        public static BondHoldings ToBonds(this IEnumerable<BondHolding> bondHoldings)
        {
            return new BondHoldings(bondHoldings);
        }

        public static LoanHoldings ToLoans(this IEnumerable<LoanHolding> loanHoldings)
        {
            return new LoanHoldings(loanHoldings);
        }
    }
}

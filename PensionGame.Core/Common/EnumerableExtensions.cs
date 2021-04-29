using PensionGame.Common.Functional;
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

        public static (IReadOnlyCollection<TA>, IReadOnlyCollection<TB>) ToTuple<TA, TB>(this IEnumerable<Union<TA, TB>> eithers)
        {
            var @as = new List<TA>();
            var bs = new List<TB>();

            foreach(var either in eithers)
            {
                either.Do(a => @as.Add(a), b => bs.Add(b));
            }

            return (@as, bs);
        }
    }
}

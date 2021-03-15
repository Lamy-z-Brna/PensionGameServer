using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PensionGame.Core.Domain.Holdings
{
    public record BondHoldings(IEnumerable<BondHolding> Bonds)  : IEnumerable<BondHolding>
    {
        public int TotalPayments => Bonds.Sum(bond => bond.YearlyPayment);

        public IEnumerator<BondHolding> GetEnumerator()
        {
            return Bonds.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Bonds.GetEnumerator();
        }
    }
}

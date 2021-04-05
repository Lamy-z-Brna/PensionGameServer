using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PensionGame.Core.Domain.Holdings
{
    public sealed record BondHoldings(IEnumerable<BondHolding> Bonds) : IEnumerable<BondHolding>
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


        public bool Equals(BondHoldings? other)
        {
            if (other == null)
                return false;

            return Enumerable.SequenceEqual(Bonds, other.Bonds);
        }

        public override int GetHashCode()
        {
            return Bonds.GetHashCode();
        }
    }
}

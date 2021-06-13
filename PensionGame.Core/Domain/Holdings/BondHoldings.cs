using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PensionGame.Core.Domain.Holdings
{
    public sealed record BondHoldings(IReadOnlyCollection<BondHolding> Bonds) : IReadOnlyCollection<BondHolding>
    {
        public BondHoldings(IEnumerable<BondHolding> bonds) : this(bonds.ToList()) { }

        public int TotalPayments => Bonds.Sum(bond => bond.YearlyPayment);

        public int Count => Bonds.Count;

        public int Value => Bonds.Sum(bond => bond.Value);

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

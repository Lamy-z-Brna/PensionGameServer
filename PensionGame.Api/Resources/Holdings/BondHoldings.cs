using System.Collections;
using System.Collections.Generic;

namespace PensionGame.Api.Resources.Holdings
{
    public record BondHoldings(IEnumerable<BondHolding> Bonds) : IEnumerable<BondHolding>
    {
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

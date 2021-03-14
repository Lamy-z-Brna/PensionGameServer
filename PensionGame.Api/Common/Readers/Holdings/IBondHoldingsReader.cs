using PensionGame.Api.Resources.Holdings;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PensionGame.Api.Common.Readers.Holdings
{
    public interface IBondHoldingsReader : IReader
    {
        Task<IEnumerable<BondHolding>> Get(int clientHoldingId);
    }
}

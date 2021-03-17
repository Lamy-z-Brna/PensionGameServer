using PensionGame.Api.Domain.Resources.Holdings;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PensionGame.Api.Data_Access.Readers.Holdings
{
    public interface IBondHoldingsReader : IReader
    {
        Task<IEnumerable<BondHolding>> Get(int clientHoldingId);
    }
}

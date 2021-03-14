using PensionGame.DataAccess.Data_Objects.Holdings;
using PensionGame.DataAccess.Data_Objects.Session;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PensionGame.DataAccess.Readers.Holdings
{
    public interface IClientHoldingsReader
    {
        Task<IEnumerable<ClientHolding>> Get(SessionId sessionId, int year);
    }
}

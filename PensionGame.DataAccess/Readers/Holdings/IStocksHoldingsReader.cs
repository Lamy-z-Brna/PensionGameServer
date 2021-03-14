using PensionGame.DataAccess.Data_Objects.Holdings;
using PensionGame.DataAccess.Data_Objects.Session;
using System.Threading.Tasks;

namespace PensionGame.DataAccess.Readers.Holdings
{
    public interface IStocksHoldingsReader : IReader
    {
        Task<StocksHolding> Get(SessionId sessionId, int year);
    }
}

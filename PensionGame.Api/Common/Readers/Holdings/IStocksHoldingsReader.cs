using PensionGame.Api.Resources.Holdings;
using System.Threading.Tasks;

namespace PensionGame.Api.Common.Readers.Holdings
{
    public interface IStocksHoldingsReader : IReader
    {
        Task<StockHolding> Get(int clientHoldingId);
    }
}

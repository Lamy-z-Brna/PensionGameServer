using PensionGame.Api.Domain.Resources.Holdings;
using System.Threading.Tasks;

namespace PensionGame.Api.Data_Access.Readers.Holdings
{
    public interface IStocksHoldingsReader : IReader
    {
        Task<StockHolding> Get(int clientHoldingId);
    }
}

using PensionGame.Api.Domain.Resources.Session;
using System.Threading.Tasks;

namespace PensionGame.Api.Data_Access.Readers.MarketData
{
    public interface IMarketDataReader : IReader
    {
        Task<Core.Domain.MarketData.MarketData> GetCurrent(SessionId sessionId);
    }
}

using PensionGame.Api.Domain.Resources.MarketData;
using PensionGame.Api.Domain.Resources.Session;
using System.Threading.Tasks;

namespace PensionGame.Api.Data_Access.Readers.MarketData
{
    public interface IReturnDataReader : IReader
    {
        Task<ReturnData> GetCurrent(SessionId sessionId);
    }
}

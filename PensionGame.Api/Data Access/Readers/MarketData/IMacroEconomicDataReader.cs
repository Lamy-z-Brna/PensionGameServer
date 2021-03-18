using PensionGame.Api.Domain.Resources.Session;
using PensionGame.Core.Domain.MarketData;
using System.Threading.Tasks;

namespace PensionGame.Api.Data_Access.Readers.MarketData
{
    public interface IMacroEconomicDataReader : IReader
    {
        Task<MacroEconomicData> GetCurrent(SessionId sessionId);
    }
}

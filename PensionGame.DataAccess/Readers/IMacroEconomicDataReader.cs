using PensionGame.DataAccess.Data_Objects;
using PensionGame.DataAccess.Data_Objects.Session;
using System.Threading.Tasks;

namespace PensionGame.DataAccess.Readers
{
    public interface IMacroEconomicDataReader : IReader
    {
        Task<MacroEconomicData> Get(SessionId session);

        Task<MacroEconomicData> Get(SessionId sessionId, int year);
    }
}

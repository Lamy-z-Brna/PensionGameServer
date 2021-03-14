using PensionGame.DataAccess.Data_Objects.ClientData;
using PensionGame.DataAccess.Data_Objects.Session;
using System.Threading.Tasks;

namespace PensionGame.DataAccess.Readers.ClientData
{
    public interface IInvestmentSelectionReader : IReader
    {
        Task<InvestmentSelection> Get(SessionId sessionId, int year);
    }
}

using PensionGame.DataAccess.Data_Objects.Session;
using System.Threading.Tasks;

namespace PensionGame.DataAccess.Readers.ClientData
{
    public interface IClientDataReader : IReader
    {
        Task<Data_Objects.ClientData.ClientData> Get(SessionId sessionId, int year);
    }
}

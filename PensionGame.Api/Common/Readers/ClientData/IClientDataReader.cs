using System.Threading.Tasks;

namespace PensionGame.Api.Common.Readers.ClientData
{
    public interface IClientDataReader : IReader
    {
        Task<Resources.ClientData.ClientData> Get(int gameStateId);
    }
}

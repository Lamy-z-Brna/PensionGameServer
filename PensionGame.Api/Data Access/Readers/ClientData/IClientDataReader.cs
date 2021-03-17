using System.Threading.Tasks;

namespace PensionGame.Api.Data_Access.Readers.ClientData
{
    public interface IClientDataReader : IReader
    {
        Task<Domain.Resources.ClientData.ClientData> Get(int gameStateId);
    }
}

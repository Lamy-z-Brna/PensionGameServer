using PensionGame.Api.Domain.Resources.ClientData;
using System.Threading.Tasks;

namespace PensionGame.Api.Data_Access.Readers.ClientData
{
    public interface IIncomeDataReader : IReader
    {
        Task<IncomeData> Get(int clientDataId);
    }
}

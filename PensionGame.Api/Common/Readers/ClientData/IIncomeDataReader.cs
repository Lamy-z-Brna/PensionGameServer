using PensionGame.Api.Resources.ClientData;
using System.Threading.Tasks;

namespace PensionGame.Api.Common.Readers.ClientData
{
    public interface IIncomeDataReader : IReader
    {
        Task<IncomeData> Get(int clientDataId);
    }
}

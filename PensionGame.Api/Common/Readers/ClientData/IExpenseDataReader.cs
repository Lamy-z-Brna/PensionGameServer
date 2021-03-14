using PensionGame.Api.Resources.ClientData;
using System.Threading.Tasks;

namespace PensionGame.Api.Common.Readers.ClientData
{
    public interface IExpenseDataReader : IReader
    {
        Task<ExpenseData> Get(int clientDataId);
    }
}

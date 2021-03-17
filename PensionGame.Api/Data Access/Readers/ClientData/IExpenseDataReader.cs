using PensionGame.Api.Domain.Resources.ClientData;
using System.Threading.Tasks;

namespace PensionGame.Api.Data_Access.Readers.ClientData
{
    public interface IExpenseDataReader : IReader
    {
        Task<ExpenseData> Get(int clientDataId);
    }
}

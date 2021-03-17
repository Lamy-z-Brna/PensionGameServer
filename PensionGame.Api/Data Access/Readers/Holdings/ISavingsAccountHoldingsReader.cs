using PensionGame.Api.Domain.Resources.Holdings;
using System.Threading.Tasks;

namespace PensionGame.Api.Data_Access.Readers.Holdings
{
    public interface ISavingsAccountHoldingsReader : IReader
    {
        Task<SavingsAccountHoldings> Get(int clientHoldingId);
    }
}

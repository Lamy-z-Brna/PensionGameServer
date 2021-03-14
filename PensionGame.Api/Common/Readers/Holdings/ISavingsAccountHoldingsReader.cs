using PensionGame.Api.Resources.Holdings;
using System.Threading.Tasks;

namespace PensionGame.Api.Common.Readers.Holdings
{
    public interface ISavingsAccountHoldingsReader : IReader
    {
        Task<SavingsAccountHoldings> Get(int clientHoldingId);
    }
}

using PensionGame.Api.Resources.Holdings;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PensionGame.Api.Common.Readers.Holdings
{
    public interface ILoanHoldingsReader : IReader
    {
        Task<IEnumerable<LoanHolding>> Get(int clientHoldingId);
    }
}

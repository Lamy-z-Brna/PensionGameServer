using PensionGame.Api.Domain.Resources.Session;
using PensionGame.Core.Domain.MarketData;
using System.Threading.Tasks;

namespace PensionGame.Api.Data_Access.Readers.MarketData
{
    public sealed class ReturnDataReader : IReturnDataReader
    {
        public async Task<ReturnData> GetCurrent(SessionId sessionId)
        {
            return new ReturnData
            (
                StockRate: 0.082,
                BondRate: 0.045,
                BondDefaultRate: 0.009,
                SavingsAccountRate: 0.02,
                LoanRate: 0.09
            );
        }
    }
}

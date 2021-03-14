using PensionGame.Api.Resources.Holdings;
using System.Threading.Tasks;

namespace PensionGame.Api.Common.Readers.Holdings
{
    public interface IClientHoldingsReader : IReader
    {
        Task<ClientHoldings> Get(int clientDataId);
    }
}

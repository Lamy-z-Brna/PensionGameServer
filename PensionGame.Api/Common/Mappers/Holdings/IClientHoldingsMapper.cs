using PensionGame.Api.Domain.Resources.Holdings;

namespace PensionGame.Api.Common.Mappers.Holdings
{
    public interface IClientHoldingsMapper : IMapper<Core.Domain.Holdings.ClientHoldings, ClientHoldings>, IMapper<ClientHoldings, Core.Domain.Holdings.ClientHoldings>
    {
    }
}

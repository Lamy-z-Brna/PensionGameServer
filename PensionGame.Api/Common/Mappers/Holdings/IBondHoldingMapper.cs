using PensionGame.Api.Domain.Resources.Holdings;

namespace PensionGame.Api.Common.Mappers.Holdings
{
    public interface IBondHoldingMapper : 
        IMapper<Core.Domain.Holdings.BondHolding, BondHolding>, 
        IMapper<BondHolding, Core.Domain.Holdings.BondHolding>
    {
    }
}

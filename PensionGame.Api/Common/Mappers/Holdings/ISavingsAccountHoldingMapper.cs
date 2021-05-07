using PensionGame.Api.Domain.Resources.Holdings;

namespace PensionGame.Api.Common.Mappers.Holdings
{
    public interface ISavingsAccountHoldingMapper : IMapper<Core.Domain.Holdings.SavingsAccountHoldings, SavingsAccountHoldings>, IMapper<SavingsAccountHoldings, Core.Domain.Holdings.SavingsAccountHoldings>
    {
    }
}

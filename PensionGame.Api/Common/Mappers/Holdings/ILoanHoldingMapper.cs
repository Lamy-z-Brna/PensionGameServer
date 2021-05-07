using PensionGame.Api.Domain.Resources.Holdings;

namespace PensionGame.Api.Common.Mappers.Holdings
{
    public interface ILoanHoldingMapper : IMapper<Core.Domain.Holdings.LoanHolding, LoanHolding>, IMapper<LoanHolding, Core.Domain.Holdings.LoanHolding>
    {
    }
}

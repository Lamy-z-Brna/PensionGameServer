using PensionGame.Api.Domain.Resources.ClientData;

namespace PensionGame.Api.Common.Mappers.ClientData
{
    public interface IInvestmentSelectionMapper : IMapper<Core.Domain.ClientData.InvestmentSelection, InvestmentSelection>, IMapper<InvestmentSelection, Core.Domain.ClientData.InvestmentSelection>
    {
    }
}

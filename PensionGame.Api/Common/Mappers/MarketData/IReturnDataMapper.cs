using PensionGame.Api.Domain.Resources.MarketData;

namespace PensionGame.Api.Common.Mappers.MarketData
{
    public interface IReturnDataMapper : IMapper<Core.Domain.MarketData.ReturnData, ReturnData>, IMapper<ReturnData, Core.Domain.MarketData.ReturnData>
    {
    }
}

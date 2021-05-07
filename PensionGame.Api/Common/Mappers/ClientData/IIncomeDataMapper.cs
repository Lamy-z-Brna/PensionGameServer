using PensionGame.Api.Domain.Resources.ClientData;

namespace PensionGame.Api.Common.Mappers.ClientData
{
    public interface IIncomeDataMapper : IMapper<Core.Domain.ClientData.IncomeData, IncomeData>, IMapper<IncomeData, Core.Domain.ClientData.IncomeData>
    {
    }
}

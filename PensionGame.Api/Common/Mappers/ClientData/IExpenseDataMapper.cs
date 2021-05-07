using PensionGame.Api.Domain.Resources.ClientData;

namespace PensionGame.Api.Common.Mappers.ClientData
{
    public interface IExpenseDataMapper : IMapper<Core.Domain.ClientData.ExpenseData, ExpenseData>, IMapper<ExpenseData, Core.Domain.ClientData.ExpenseData>
    {
    }
}

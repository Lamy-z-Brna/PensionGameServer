using PensionGame.Api.Domain.Resources.Holdings;
using PensionGame.Api.Handlers.Common;
using PensionGame.Api.Handlers.Queries;

namespace PensionGame.Api.Handlers.QueryHandlers
{
    public interface IGetAvailableToInvestQueryHandler : IQueryHandler<GetAvailableToInvestQuery, AvailableToInvest>, IQueryHandler<GetAvailableToInvestFromSessionQuery, AvailableToInvest?>
    {
    }
}

using PensionGame.Api.Domain.Resources.Holdings;
using PensionGame.Api.Domain.Resources.Session;
using PensionGame.Api.Handlers.Common;

namespace PensionGame.Api.Handlers.Queries
{
    public record GetPortfolioReturnRateQuery(SessionId SessionId) : IQuery<PortfolioReturnRate>
    {
    }
}

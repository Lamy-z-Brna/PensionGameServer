using PensionGame.Api.Domain.Common;
using PensionGame.Api.Domain.Resources.Session;
using PensionGame.Api.Handlers.Common;
using PensionGame.Api.Handlers.Queries;

namespace PensionGame.Api.Handlers.QueryHandlers
{
    public interface IGetSessionInfosQueryHandler : IQueryHandler<GetSessionInfosQuery, PaginatedCollection<SessionInfo>>
    {
    }
}

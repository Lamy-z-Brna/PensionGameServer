using PensionGame.Api.Domain.Common;
using PensionGame.Api.Domain.Resources.Session;
using PensionGame.Api.Handlers.Common;

namespace PensionGame.Api.Handlers.Queries
{
    public record GetSessionsQuery(int Page, int PageSize) : IQuery<PaginationResult<Session>>
    {
    }
}

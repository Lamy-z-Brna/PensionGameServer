using PensionGame.Api.Domain.Common;
using PensionGame.Api.Domain.Resources.Session;
using PensionGame.Api.Handlers.Common;

namespace PensionGame.Api.Handlers.Queries
{
    public record GetSessionInfosQuery : IQuery<PaginatedCollection<SessionInfo>>
    {
        public int Page { get; }

        public int PageSize { get; }

        private const int DefaultPage = 1;

        private const int DefaultPageSize = 50;

        public GetSessionInfosQuery(int? page, int? pageSize)
        {
            Page = page == null || page <= 0 ? DefaultPage : page.Value;
            PageSize = pageSize == null || pageSize >= DefaultPageSize || pageSize <= 0 ? DefaultPageSize : pageSize.Value;
        }
    }
}

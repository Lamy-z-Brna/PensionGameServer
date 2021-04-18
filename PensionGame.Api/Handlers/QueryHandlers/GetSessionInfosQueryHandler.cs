using PensionGame.Api.Data_Access.Readers.Session;
using PensionGame.Api.Domain.Common;
using PensionGame.Api.Domain.Resources.Session;
using PensionGame.Api.Handlers.Queries;
using System.Threading.Tasks;

namespace PensionGame.Api.Handlers.QueryHandlers
{
    public sealed class GetSessionInfosQueryHandler : IGetSessionInfosQueryHandler
    {
        private readonly ISessionInfoReader _sessionInfoReader;

        public GetSessionInfosQueryHandler(ISessionInfoReader sessionInfoReader)
        {
            _sessionInfoReader = sessionInfoReader;
        }

        public async Task<PaginatedCollection<SessionInfo>> Handle(GetSessionInfosQuery query)
        {
            var sessions = await _sessionInfoReader.GetAll(query.Page, query.PageSize);

            return sessions;
        }
    }
}

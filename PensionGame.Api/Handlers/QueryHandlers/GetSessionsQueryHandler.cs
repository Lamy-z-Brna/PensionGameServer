using PensionGame.Api.Data_Access.Readers.Session;
using PensionGame.Api.Domain.Common;
using PensionGame.Api.Domain.Resources.Session;
using PensionGame.Api.Handlers.Queries;
using System.Threading.Tasks;

namespace PensionGame.Api.Handlers.QueryHandlers
{
    public sealed class GetSessionsQueryHandler : IGetSessionsQueryHandler
    {
        private readonly ISessionReader _sessionReader;

        public GetSessionsQueryHandler(ISessionReader sessionReader)
        {
            _sessionReader = sessionReader;
        }

        public async Task<PaginationResult<Session>> Handle(GetSessionsQuery query)
        {
            return await _sessionReader.GetAll(query.Page, query.PageSize);
        }
    }
}

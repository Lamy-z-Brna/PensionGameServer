using PensionGame.Api.Data_Access.Readers.Session;
using PensionGame.Api.Domain.Resources.Session;
using PensionGame.Api.Handlers.Queries;
using System.Threading.Tasks;

namespace PensionGame.Api.Handlers.QueryHandlers
{
    public sealed class GetSessionQueryHandler : IGetSessionQueryHandler
    {
        private readonly ISessionReader _sessionReader;

        public GetSessionQueryHandler(ISessionReader sessionReader)
        {
            _sessionReader = sessionReader;
        }

        public async Task<Session?> Handle(GetSessionQuery query)
        {
            var result = await _sessionReader.Get(query.SessionId);
            return result;
        }
    }
}

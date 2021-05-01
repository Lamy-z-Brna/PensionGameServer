using PensionGame.Api.Domain.Resources.Session;
using PensionGame.Api.Domain.Common;
using PensionGame.Web.Client;
using RestSharp;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace PensionGame.Web.Services
{
    public class SessionDataServices
    {
        private readonly IServiceClient _client;

        public SessionDataServices(IServiceClient client)
        {
            _client = client;
        }

        public async Task<SessionId?> CreateDefaultSession()
        {
            return await _client.Request<SessionId>("Session/Default", Method.POST);
        }

        public async Task<SessionId?> CreateSession(StartupParameters session, string name)
        {
            return await _client.Request<SessionId>("Session/New", Method.POST, session,
                new Dictionary<string, object> { { "name", name } });
        }

        public async Task<PaginatedCollection<SessionInfo>?> GetAllSessions(int page = 1, int pageSize = 50)
        {
            return await _client.Request<PaginatedCollection<SessionInfo>>("Session/GetAll", Method.GET,
                parameters: new Dictionary<string, object> { { "page", page }, { "pageSize", pageSize } });
        }
    }
}

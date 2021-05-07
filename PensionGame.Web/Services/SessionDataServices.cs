using PensionGame.Api.Domain.Resources.Session;
using PensionGame.Api.Domain.Common;
using PensionGame.Web.Client;
using System.Threading.Tasks;
using System.Collections.Generic;
using PensionGame.Api.Domain.Validation;
using PensionGame.Common.Functional;

namespace PensionGame.Web.Services
{
    public sealed class SessionDataServices
    {
        private readonly IServiceClient _client;

        public SessionDataServices(IServiceClient client)
        {
            _client = client;
        }

        public async Task<Union<SessionId, ValidationResultModel>> CreateSession(StartupParameters session, string name)
        {
            return await _client.Post<SessionId>("Session/New", session,
                new Dictionary<string, object> { { "name", name } });
        }

        public async Task<ValidationResultModel> ValidateSession(StartupParameters session, string name)
        {
            return await _client.Put("Session/New", session,
                new Dictionary<string, object> { { "name", name } });
        }

        public async Task<PaginatedCollection<SessionInfo>?> GetAllSessions(int page = 1, int pageSize = 50)
        {
            return await _client.Get<PaginatedCollection<SessionInfo>>("Session/GetAll", 
                parameters: new Dictionary<string, object> { { "page", page }, { "pageSize", pageSize } });
        }
    }
}

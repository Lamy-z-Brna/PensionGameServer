using PensionGame.Api.Domain.Resources.Session;
using PensionGame.Web.Client;
using RestSharp;
using System.Threading.Tasks;

namespace PensionGame.Web.Services
{
    public class SessionDataServices
    {
        private readonly IServiceClient _client;

        public SessionDataServices(IServiceClient client)
        {
            _client = client;
        }

        public async Task<SessionId> CreateDefaultSession()
        {
            return await _client.Request<SessionId>("Session/Default", Method.POST);
        }

        public async Task<SessionId> CreateSession(StartupParameters session)
        {
            return await _client.Request<SessionId>("Session/New", Method.POST, session);
        }
    }
}

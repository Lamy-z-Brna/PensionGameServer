using System.Threading.Tasks;
using PensionGame.Web.Client;
using PensionGame.Web.Data.Entities;
using RestSharp;

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

        public async Task<SessionId> CreateSession(Session session)
        {
            return await _client.Request<SessionId>("Session/New", Method.POST, session);
        }
    }
}

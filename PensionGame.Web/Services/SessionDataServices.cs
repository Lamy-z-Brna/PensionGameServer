using System.Threading.Tasks;
using PensionGame.Web.Client;
using PensionGame.Web.Data.Entities;

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
            return await _client.PostRequest<SessionId>("Session/Default");
        }

        public async Task<SessionId> CreateSession(Session session)
        {
            return await _client.PostRequest<SessionId>("Session/New", session);
        }
    }
}

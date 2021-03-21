using System.Threading.Tasks;
using PensionGame.Web.Data.Entities;

namespace PensionGame.Web.Services
{
    public class SessionDataServices : ServicesBase
    {
        public async Task<SessionId> DefaultSessionPost()
        {
            return await Client.PostRequest<SessionId>("Session/Default");
        }

        public async Task<SessionId> SessionPost(Session session)
        {
            return await Client.PostRequest<SessionId>("Session/New", session);
        }
    }
}

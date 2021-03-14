using PensionGame.Api.Resources.Session;
using System.Threading.Tasks;

namespace PensionGame.Api.Common.Readers.Session
{
    public interface ISessionReader : IReader
    {
        Task<Resources.Session.Session> Get(SessionId sessionId);
    }
}

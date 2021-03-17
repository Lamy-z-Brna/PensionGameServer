using PensionGame.Api.Domain.Resources.Session;
using System.Threading.Tasks;

namespace PensionGame.Api.Data_Access.Readers.Session
{
    public interface ISessionReader : IReader
    {
        Task<Domain.Resources.Session.Session> Get(SessionId sessionId);
    }
}

using PensionGame.Api.Domain.Common;
using PensionGame.Api.Domain.Resources.Session;
using System.Threading.Tasks;

namespace PensionGame.Api.Data_Access.Readers.Session
{
    public interface ISessionReader : IReader
    {
        Task<Domain.Resources.Session.Session?> Get(SessionId sessionId);

        Task<PaginatedCollection<Domain.Resources.Session.Session>> GetAll(int page, int pageSize);
    }
}

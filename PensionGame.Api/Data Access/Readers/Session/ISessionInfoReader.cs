using PensionGame.Api.Domain.Common;
using PensionGame.Api.Domain.Resources.Session;
using System.Threading.Tasks;

namespace PensionGame.Api.Data_Access.Readers.Session
{
    public interface ISessionInfoReader : IReader
    {
        Task<PaginatedCollection<SessionInfo>> GetAll(int page, int pageSize);
    }
}

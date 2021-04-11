using PensionGame.Api.Domain.Common;
using System.Threading.Tasks;

namespace PensionGame.Api.Data_Access.Readers.Session
{
    public interface ISessionReader : IReader
    {
        Task<PaginationResult<Domain.Resources.Session.Session>> GetAll(int page, int pageSize);
    }
}

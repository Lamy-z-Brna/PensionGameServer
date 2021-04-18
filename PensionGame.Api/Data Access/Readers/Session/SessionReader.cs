using PensionGame.Api.Common.Mappers;
using PensionGame.Api.Data_Access.Connection;
using PensionGame.Api.Domain.Common;
using System.Threading.Tasks;

namespace PensionGame.Api.Data_Access.Readers.Session
{
    public sealed class SessionReader : ISessionReader
    {
        private readonly SessionDatabase _sessionDatabase;
        private readonly IPaginationResultMapper<Data_Objects.Session, Domain.Resources.Session.Session> _sessionMapper;

        public SessionReader(SessionDatabase sessionDatabase, 
            IPaginationResultMapper<Data_Objects.Session, Domain.Resources.Session.Session> sessionMapper)
        {
            _sessionDatabase = sessionDatabase;
            _sessionMapper = sessionMapper;
        }

        public async Task<PaginatedCollection<Domain.Resources.Session.Session>> GetAll(int page, int pageSize)
        {
            var result = await _sessionDatabase.Get(page, pageSize);

            return _sessionMapper.Map(result);
        }
    }
}

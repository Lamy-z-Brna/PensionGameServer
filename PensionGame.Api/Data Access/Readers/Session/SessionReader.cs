using PensionGame.Api.Common.Mappers;
using PensionGame.Api.Data_Access.Connection;
using PensionGame.Api.Domain.Common;
using PensionGame.Api.Domain.Resources.Session;
using System.Threading.Tasks;

namespace PensionGame.Api.Data_Access.Readers.Session
{
    public sealed class SessionReader : ISessionReader
    {
        private readonly SessionDatabase _sessionDatabase;
        private readonly IMapper<Data_Objects.Session, Domain.Resources.Session.Session> _sessionMapper;
        private readonly IPaginationResultMapper<Data_Objects.Session, Domain.Resources.Session.Session> _sessionsMapper;

        public SessionReader(SessionDatabase sessionDatabase,
            IPaginationResultMapper<Data_Objects.Session, Domain.Resources.Session.Session> sessionsMapper, 
            IMapper<Data_Objects.Session, Domain.Resources.Session.Session> sessionMapper)
        {
            _sessionDatabase = sessionDatabase;
            _sessionsMapper = sessionsMapper;
            _sessionMapper = sessionMapper;
        }

        public async Task<Domain.Resources.Session.Session?> Get(SessionId sessionId)
        {
            var result = await _sessionDatabase.Get(sessionId.Id);

            if (result == null)
                return null;

            return _sessionMapper.Map(result);
        }

    public async Task<PaginatedCollection<Domain.Resources.Session.Session>> GetAll(int page, int pageSize)
        {
            var result = await _sessionDatabase.Get(page, pageSize);

            return _sessionsMapper.Map(result);
        }
    }
}

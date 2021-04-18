using MongoDB.Driver;
using PensionGame.Api.Data_Access.ConnectionSettings;
using PensionGame.Api.Data_Access.Data_Objects;
using PensionGame.Api.Data_Access.Helpers;
using PensionGame.Api.Domain.Common;
using System.Linq;
using System.Threading.Tasks;

namespace PensionGame.Api.Data_Access.Connection
{
    public sealed class SessionDatabase : Database<Session>
    {
        private IMongoCollection<Session> Sessions => ObjectCollection;

        public SessionDatabase(SessionConnectionSettings sessionConnectionSettings) : base(sessionConnectionSettings)
        {
        }

        public async Task Create(Session session)
        {
            await Sessions.InsertOneAsync(session);
        }

        public async Task<PaginatedCollection<Session>> Get(int page, int pageSize)
        {
            var result = await Sessions
                .AggregateByPage(
                    Builders<Session>.Filter.Empty,
                    Builders<Session>.Sort.Descending(session =>  session.Object!.DateStarted),
                    page,
                    pageSize
                );

            var (totalPages, totalCount, data) = result;

            return new PaginatedCollection<Session>(data, page, data.Count(), totalCount, totalPages);
        }
    }
}

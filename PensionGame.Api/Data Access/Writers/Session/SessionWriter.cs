using PensionGame.Api.Data_Access.Connection;
using PensionGame.Api.Domain.Resources.Session;
using System;
using System.Threading.Tasks;

namespace PensionGame.Api.Data_Access.Writers.Session
{
    public class SessionWriter : ISessionWriter
    {
        private readonly SessionDatabase _sessionDatabase;

        public SessionWriter(SessionDatabase sessionDatabase)
        {
            _sessionDatabase = sessionDatabase;
        }

        public async Task<SessionId> Create(int Income, int Expenses, int Year, int RetirementYear, string Name)
        {
            var sessionId = new SessionId(Guid.NewGuid());

            await _sessionDatabase.Create(new Data_Objects.Session
            {
                Object = new Domain.Resources.Session.Session
                (
                    SessionId: sessionId,
                    DateStarted: DateTime.Now,
                    Name: Name,
                    StartupParameters: new StartupParameters
                    (
                        Income,
                        Expenses,
                        Year,
                        RetirementYear
                    )
                )
            });

            return sessionId;
        }
    }
}

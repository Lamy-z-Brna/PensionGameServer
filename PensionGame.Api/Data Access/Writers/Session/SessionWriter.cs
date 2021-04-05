using PensionGame.Api.Domain.Resources.Session;
using System;
using System.Threading.Tasks;

namespace PensionGame.Api.Data_Access.Writers.Session
{
    public class SessionWriter : ISessionWriter
    {
        public async Task<SessionId> Create(int Income, int Expenses, int Year, int RetirementYear)
        {
            var guid = await Task.Run(() => Guid.NewGuid());

            return new SessionId(guid);
        }
    }
}

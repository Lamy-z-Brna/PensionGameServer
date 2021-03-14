using PensionGame.DataAccess.Data_Objects.Session;
using System;
using System.Threading.Tasks;

namespace PensionGame.DataAccess.Writers.Session
{
    public sealed class SessionWriter : ISessionWriter
    {
        public async Task<SessionId> Create(int Income, int Expenses, int Year, int RetirementYear)
        {
            var guid = await Task.Run(() => Guid.NewGuid());

            return new SessionId(guid);
        }
    }
}

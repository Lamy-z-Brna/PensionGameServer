using PensionGame.Api.Resources.Session;
using PensionGame.DataAccess;
using System;
using System.Threading.Tasks;

namespace PensionGame.Api.Common.Writers.Session
{
    public class SessionWriter : ISessionWriter
    {
        private readonly PensionGameDbContext _context;
        public SessionWriter(PensionGameDbContext context)
        {
            _context = context;
        }
        public async Task<SessionId> Create(int Income, int Expenses, int Year, int RetirementYear)
        {
            var guid = await Task.Run(() => Guid.NewGuid());

            var testSession = new DataAccess.Data_Objects.Session.Session { DateStarted = DateTime.Now };
            _context.Add(testSession);
            await _context.SaveChangesAsync();

            return new SessionId(guid);
        }
    }
}

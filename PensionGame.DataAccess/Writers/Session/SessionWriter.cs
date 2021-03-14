using PensionGame.DataAccess.Data_Objects.Session;
using System;
using System.Threading.Tasks;

namespace PensionGame.DataAccess.Writers.Session
{
    public sealed class SessionWriter : ISessionWriter
    {
        private readonly PensionGameDbContext _context;
        public SessionWriter(PensionGameDbContext context)
        {
            _context = context;
        }
        public async Task<SessionId> Create(int Income, int Expenses, int Year, int RetirementYear)
        {
            var guid = await Task.Run(() => Guid.NewGuid());

            var testSession = new Data_Objects.Session.Session { DateStarted = DateTime.Now };
            _context.Add(testSession);
            await _context.SaveChangesAsync();

            return new SessionId(guid);
        }
    }
}

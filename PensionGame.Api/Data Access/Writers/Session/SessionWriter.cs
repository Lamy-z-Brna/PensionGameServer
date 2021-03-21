using PensionGame.Api.Domain.Resources.Session;
using PensionGame.DataAccess;
using PensionGame.DataAccess.Data_Objects.GameData;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PensionGame.Api.Data_Access.Writers.Session
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

            var testSession = new DataAccess.Data_Objects.Session.Session { DateStarted = DateTime.Now, GameStates = new List<GameState>() };
            _context.Add(testSession);
            await _context.SaveChangesAsync();

            return new SessionId(ToGuid(testSession.Id));
        }

        private Guid ToGuid(int value)
        {
            byte[] bytes = new byte[16];
            BitConverter.GetBytes(value).CopyTo(bytes, 0);
            return new Guid(bytes);
        }

        private int FromGuid(Guid value)
        {
            byte[] b = value.ToByteArray();
            int bint = BitConverter.ToInt32(b, 0);
            return bint;
        }
    }
}

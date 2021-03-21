using PensionGame.Api.Domain.Resources.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionGame.Api.Data_Access.Readers.Session
{
    public class SessionReader : ISessionReader
    {
        public Task<Domain.Resources.Session.Session> Get(SessionId sessionId)
        {
            throw new NotImplementedException();
        }
    }
}

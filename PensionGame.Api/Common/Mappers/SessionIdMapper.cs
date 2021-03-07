using PensionGame.Api.Domain.Session;

namespace PensionGame.Api.Common.Mappers
{
    public sealed class SessionIdMapper : ISessionIdMapper
    {
        public SessionId Map(DataAccess.Data_Objects.Session.SessionId @in)
        {
            return new SessionId(@in.Id);
        }
    }
}

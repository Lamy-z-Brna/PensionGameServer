namespace PensionGame.Api.Common.Mappers
{
    public sealed class SessionMapper : ISessionMapper
    {
        public Domain.Resources.Session.Session Map(Data_Access.Data_Objects.Session session)
        {
            return session.Object!;
        }
    }
}

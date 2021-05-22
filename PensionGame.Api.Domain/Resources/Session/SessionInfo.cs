namespace PensionGame.Api.Domain.Resources.Session
{
    public record SessionInfo(Session Session, int CurrentYear, bool IsFinished)
    {
    }
}

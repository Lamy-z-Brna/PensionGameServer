namespace PensionGame.Api.Domain.Resources.Events
{
    public record Event(string EventName, string DisplayMessage, EventType EventType = EventType.Info)
    {
    }
}

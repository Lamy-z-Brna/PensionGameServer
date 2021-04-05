using PensionGame.Core.Events.PreClientDataEvents;

namespace PensionGame.Core.Events
{
    public record UnemploymentEvent(double IncomeLoss) : IPreClientDataEvent
    {
    }
}

using PensionGame.Core.Events.Common;

namespace PensionGame.Core.Events
{
    public record UnemploymentEvent(double IncomeLoss) : IEvent
    {
    }
}

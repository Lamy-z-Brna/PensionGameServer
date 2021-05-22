using PensionGame.Core.Events.Common;
using PensionGame.Core.Events.PreClientDataEvents;

namespace PensionGame.Core.Events
{
    public record UnemploymentEvent(double IncomeLoss) : PreClientDataEvent
    {
        public override EventType EventType => EventType.Unemployment;
    }
}

using PensionGame.Core.Domain.Holdings;
using PensionGame.Core.Events.Common;

namespace PensionGame.Core.Events
{
    public record BondDefaultEvent(BondHolding BondHolding) : Event
    {
        public override EventType EventType => EventType.BondDefault;
    }
}

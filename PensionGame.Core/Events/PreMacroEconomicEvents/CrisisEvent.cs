using PensionGame.Core.Events.Common;

namespace PensionGame.Core.Events.PreMacroEconomicEvents
{
    public record CrisisEvent() : PreMacroEconomicEvent
    {
        public override EventType EventType => EventType.Crisis;
    }
}

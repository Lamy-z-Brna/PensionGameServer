using PensionGame.Core.Events.Common;

namespace PensionGame.Core.Events.PreClientDataEvents
{
    public record AutomaticSavingsAccountInvestmentEvent(int AmountRequested, int AmountAutomaticallyInvested) : Event
    {
        public int TotalInvested => AmountRequested + AmountAutomaticallyInvested;

        public override EventType EventType => EventType.AutomaticSavingsAccountInvestment;
    }
}
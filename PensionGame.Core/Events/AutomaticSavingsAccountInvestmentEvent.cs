using PensionGame.Core.Events.Common;

namespace PensionGame.Core.Events.PreClientDataEvents
{
    public record AutomaticSavingsAccountInvestmentEvent(int AmountRequested, int AmountAutomaticallyInvested) : IEvent
    {
        public int TotalInvested => AmountRequested + AmountAutomaticallyInvested;
    }
}

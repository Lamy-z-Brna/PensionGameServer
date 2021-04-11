namespace PensionGame.Core.Events.PreClientDataEvents
{
    public record AutomaticSavingsAccountInvestmentEvent(int AmountRequested, int AmountAutomaticallyInvested) : IPreClientDataEvent
    {
        public int TotalInvested => AmountRequested + AmountAutomaticallyInvested;
    }
}

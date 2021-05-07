using PensionGame.Api.Domain.Resources.Events;
using PensionGame.Core.Events;
using PensionGame.Core.Events.Common;
using PensionGame.Core.Events.PreClientDataEvents;
using PensionGame.Core.Events.PreMacroEconomicEvents;
using System;

namespace PensionGame.Api.Common.Mappers.Events
{
    public sealed class EventMapper : IEventMapper
    {
        public Event Map(IEvent source)
        {
            return source switch
            {
                UnemploymentEvent ue => new Event($"You've become unemployed, reducing your salary by {ue.IncomeLoss * 100} %", EventType.Negative),
                CrisisEvent => new Event("The economy is experiencing a downturn. Your returns might be lower and the risk of unemployment is higher", EventType.Negative),
                AutomaticSavingsAccountInvestmentEvent ae => new Event($"You have not fully invested all your investments. Remaining balance of {ae.AmountAutomaticallyInvested} has been automatically invested into savings account."),
                BondDefaultEvent bde => new Event($"Bond that paid out {bde.BondHolding.YearlyPayment} and expired in {bde.BondHolding.YearsToExpiration} years has defaulted on payments and won't no longer pay out", EventType.Negative),
                _ => throw new NotImplementedException()
            };
        }
    }
}

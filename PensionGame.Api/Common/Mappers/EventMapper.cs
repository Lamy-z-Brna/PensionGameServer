using PensionGame.Api.Domain.Resources.Events;
using PensionGame.Core.Events;
using PensionGame.Core.Events.Common;
using PensionGame.Core.Events.PreMacroEconomicEvents;
using System;

namespace PensionGame.Api.Common.Mappers
{
    public sealed class EventMapper : IEventMapper
    {
        public Event Map(IEvent source)
        {
            return source switch
            {
                UnemploymentEvent ue => new Event($"You've become unemployed, reducing your salary by {ue.IncomeLoss * 100} %"),
                CrisisEvent => new Event("Market has experienced a crash. Your returns might be lower and the risk of unemployment is higher"),
                _ => throw new NotImplementedException()
            };
        }
    }
}

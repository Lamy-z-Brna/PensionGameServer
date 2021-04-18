using PensionGame.Api.Domain.Resources.Events;
using System.Collections.Generic;

namespace PensionGame.Api.Domain.Resources.GameData
{
    public record GameState(int Year, int RetirementYear, ClientData.ClientData ClientData, MarketData.MarketData MarketData, IReadOnlyCollection<Event> Events, bool IsInitial = false)
    {
        public bool IsFinished => Year >= RetirementYear;
    }
}

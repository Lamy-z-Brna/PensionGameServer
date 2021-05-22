using PensionGame.Core.Events.Common;
using System.Collections.Generic;

namespace PensionGame.Core.Domain.GameData
{
    public record GameState(int Year, int RetirementYear, ClientData.ClientData ClientData, MarketData.MarketData MarketData, IReadOnlyCollection<Event> Events, bool IsInitial = false)
    {
        public bool IsFinished => Year >= RetirementYear;
    }
}

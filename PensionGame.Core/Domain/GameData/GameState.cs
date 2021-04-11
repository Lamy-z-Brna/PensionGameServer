using PensionGame.Core.Events.Common;
using System.Collections.Generic;

namespace PensionGame.Core.Domain.GameData
{
    public record GameState(int Year, int RetirementYear, ClientData.ClientData ClientData, MarketData.MarketData MarketData, IEnumerable<IEvent> Events)
    {
        public bool IsFinished => Year >= RetirementYear;
    }
}

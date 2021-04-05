using PensionGame.Core.Events.Common;
using System.Collections.Generic;

namespace PensionGame.Core.Domain.GameData
{
    public record GameState(int Year, ClientData.ClientData ClientData, MarketData.MarketData MarketData, bool IsFinished, IEnumerable<IEvent> Events)
    {
    }
}

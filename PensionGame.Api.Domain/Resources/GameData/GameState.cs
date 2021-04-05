using PensionGame.Api.Domain.Resources.Events;
using System.Collections.Generic;

namespace PensionGame.Api.Domain.Resources.GameData
{
    public record GameState(int Year, ClientData.ClientData ClientData, MarketData.MarketData MarketData, bool IsFinished, IEnumerable<Event> Events, bool IsInitial = false)
    {  
    }
}

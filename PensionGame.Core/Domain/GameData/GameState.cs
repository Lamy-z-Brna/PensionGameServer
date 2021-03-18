namespace PensionGame.Core.Domain.GameData
{
    public record GameState(int Year, ClientData.ClientData ClientData, MarketData.MarketData MarketData, bool IsFinished)
    {
    }
}

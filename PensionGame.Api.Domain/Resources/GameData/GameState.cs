namespace PensionGame.Api.Domain.Resources.GameData
{
    public record GameState(int Year, ClientData.ClientData ClientData, MarketData.MarketData MarketData, bool IsInitial, bool IsFinished)
    {
    }
}

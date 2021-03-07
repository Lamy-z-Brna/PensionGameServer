namespace PensionGame.Core.Domain.GameData
{
    public record GameState(int Year, ClientData.ClientData ClientData, bool IsFinished)
    {
    }
}

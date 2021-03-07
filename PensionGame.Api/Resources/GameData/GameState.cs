namespace PensionGame.Api.Resources.GameData
{
    public record GameState(int Year, ClientData.ClientData ClientData, bool IsFinished)
    {
    }
}

using PensionGame.Api.Domain.Resources.ClientData;

namespace PensionGame.Api.Domain.Resources.GameData
{
    public record NextGameStateCommand(GameState GameState, InvestmentSelection InvestmentSelection)
    {
    }
}

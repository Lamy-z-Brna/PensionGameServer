using PensionGame.Api.Domain.Resources.ClientData;
using PensionGame.Api.Domain.Resources.GameData;
using PensionGame.Api.Handlers.Common;

namespace PensionGame.Api.Handlers.Commands
{
    public record CheckInvestmentSelectionCommand(GameState GameState, InvestmentSelection InvestmentSelection) : ICommand
    {
    }
}

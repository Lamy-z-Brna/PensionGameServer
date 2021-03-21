using PensionGame.Api.Handlers.Common;
using PensionGame.Api.Domain.Resources.ClientData;
using PensionGame.Api.Domain.Resources.GameData;

namespace PensionGame.Api.Handlers.Commands
{
    public record CheckInvestmentSelectionCommand(GameState GameState, InvestmentSelection InvestmentSelection) : ICommand
    {
    }
}

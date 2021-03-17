using PensionGame.Api.Handlers.Common;
using PensionGame.Api.Domain.Resources.ClientData;
using PensionGame.Api.Domain.Resources.Session;

namespace PensionGame.Api.Handlers.Commands
{
    public record CheckInvestmentSelectionCommand(SessionId SessionId, InvestmentSelection InvestmentSelection) : ICommand
    {
    }
}

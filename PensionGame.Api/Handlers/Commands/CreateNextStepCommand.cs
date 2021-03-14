using PensionGame.Api.Handlers.Common;
using PensionGame.Api.Resources.ClientData;
using PensionGame.Api.Resources.Session;

namespace PensionGame.Api.Handlers.Commands
{
    public record CreateNextStepCommand(SessionId SessionId, InvestmentSelection InvestmentSelection) : ICommand
    {
    }
}

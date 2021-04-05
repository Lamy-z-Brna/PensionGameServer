using PensionGame.Api.Domain.Resources.ClientData;
using PensionGame.Api.Domain.Resources.Session;
using PensionGame.Api.Handlers.Common;

namespace PensionGame.Api.Handlers.Commands
{
    public record CreateNextStepCommand(SessionId SessionId, InvestmentSelection InvestmentSelection) : ICommand
    {
    }
}

using PensionGame.Api.Domain.Resources.GameData;
using PensionGame.Api.Handlers.Commands;
using PensionGame.Api.Handlers.Common;

namespace PensionGame.Api.Handlers.CommandHandlers
{
    public interface IGetNextStepCommandHandler : ICommandHandler<GetNextStepCommand, GameState>
    {
    }
}

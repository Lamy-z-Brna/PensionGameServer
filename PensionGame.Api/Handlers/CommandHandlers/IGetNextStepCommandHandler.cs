using PensionGame.Api.Domain.Resources.GameData;
using PensionGame.Api.Handlers.Commands;
using PensionGame.Api.Handlers.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionGame.Api.Handlers.CommandHandlers
{
    public interface IGetNextStepCommandHandler : ICommandHandler<GetNextStepCommand, GameState>
    {
    }
}

using PensionGame.Api.Domain.Resources.ClientData;
using PensionGame.Api.Domain.Resources.GameData;
using PensionGame.Api.Handlers.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionGame.Api.Handlers.Commands
{
    public record GetNextStepCommand(GameState GameState, InvestmentSelection InvestmentSelection) : ICommand<GameState>
    {
    }
}

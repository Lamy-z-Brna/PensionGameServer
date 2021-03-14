using PensionGame.Api.Domain.Session;
using PensionGame.Api.Handlers.Common;
using PensionGame.Api.Resources.ClientData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionGame.Api.Handlers.Commands
{
    public record CreateNextStepCommand(SessionId SessionId, InvestmentSelection InvestmentSelection) : ICommand
    {
    }
}

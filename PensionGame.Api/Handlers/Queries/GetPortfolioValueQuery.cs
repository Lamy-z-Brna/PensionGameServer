using PensionGame.Api.Domain.Resources.Holdings;
using PensionGame.Api.Domain.Resources.Session;
using PensionGame.Api.Handlers.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionGame.Api.Handlers.Queries
{
    public record GetPortfolioValueQuery(SessionId SessionId) : IQuery<PortfolioValue?>
    {
    }
}

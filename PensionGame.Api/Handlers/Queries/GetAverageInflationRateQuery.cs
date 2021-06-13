using PensionGame.Api.Domain.Resources.MarketData;
using PensionGame.Api.Domain.Resources.Session;
using PensionGame.Api.Handlers.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionGame.Api.Handlers.Queries
{
    public record GetAverageInflationRateQuery(SessionId SessionId) : IQuery<AverageInflationRate?>
    {
    }
}

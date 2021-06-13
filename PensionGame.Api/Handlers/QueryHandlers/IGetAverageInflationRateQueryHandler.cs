using PensionGame.Api.Domain.Resources.MarketData;
using PensionGame.Api.Handlers.Common;
using PensionGame.Api.Handlers.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionGame.Api.Handlers.QueryHandlers
{
    public interface IGetAverageInflationRateQueryHandler : IQueryHandler<GetAverageInflationRateQuery, AverageInflationRate?>
    {
    }
}

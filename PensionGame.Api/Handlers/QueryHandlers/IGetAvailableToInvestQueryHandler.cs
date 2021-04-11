using PensionGame.Api.Domain.Resources.Holdings;
using PensionGame.Api.Handlers.Common;
using PensionGame.Api.Handlers.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionGame.Api.Handlers.QueryHandlers
{
    public interface IGetAvailableToInvestQueryHandler : IQueryHandler<GetAvailableToInvestQuery, AvailableToInvest>, IQueryHandler<GetAvailableToInvestFromSessionQuery, AvailableToInvest?>
    {
    }
}

using PensionGame.Api.Domain.Resources.Holdings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionGame.Api.Common.Mappers.Holdings
{
    public interface IPortfolioValueMapper : IMapper<Core.Domain.Holdings.PortfolioValue, PortfolioValue>
    {
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionGame.Api.Common.Mappers.Holdings
{
    public sealed class PortfolioValueMapper : IPortfolioValueMapper
    {
        public Domain.Resources.Holdings.PortfolioValue Map(Core.Domain.Holdings.PortfolioValue portfolioValue)
        {
            return new(portfolioValue.Value);
        }
    }
}

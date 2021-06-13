using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionGame.Api.Common.Mappers.MarketData
{
    public sealed class AverageInflationRateMapper : IAverageInflationRateMapper
    {
        public Domain.Resources.MarketData.AverageInflationRate Map(Core.Domain.MarketData.AverageInflationRate averageInflationRate)
        {
            return new(averageInflationRate.InflationRate);
        }
    }
}

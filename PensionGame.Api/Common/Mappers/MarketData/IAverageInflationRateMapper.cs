using PensionGame.Api.Domain.Resources.MarketData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionGame.Api.Common.Mappers.MarketData
{
    public interface IAverageInflationRateMapper : IMapper<Core.Domain.MarketData.AverageInflationRate, AverageInflationRate>
    {
    }
}

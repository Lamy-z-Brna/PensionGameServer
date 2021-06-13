using PensionGame.Core.Calculators.Common;
using PensionGame.Core.Calculators.RequiredData;
using PensionGame.Core.Domain.MarketData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionGame.Core.Calculators.MarketData
{
    public interface IAverageInflationRateCalculator : ICalculator<AverageInflationRateRequiredData, AverageInflationRate?>
    {
    }
}

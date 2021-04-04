using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionGame.DataAccess.Data_Objects.MarketData
{
    public record MarketData(MacroEconomicData MacroEconomicData, ReturnData ReturnData)
    {
    }
}

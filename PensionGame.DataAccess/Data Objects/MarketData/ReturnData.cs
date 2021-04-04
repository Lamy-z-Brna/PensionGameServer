using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionGame.DataAccess.Data_Objects.MarketData
{
    public record ReturnData(double StockRate, double BondRate, double BondDefaultRate, double SavingsAccountRate, double LoanRate)
    {
    }
}

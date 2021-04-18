using PensionGame.Core.Domain.Holdings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionGame.Core.Calculators.RequiredData
{
    public record BondDefaultRequiredData(BondHolding BondHolding, double BondDefaultRate)
    {
    }
}

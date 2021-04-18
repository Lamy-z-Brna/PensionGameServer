using PensionGame.Core.Calculators.Common;
using PensionGame.Core.Calculators.RequiredData;
using PensionGame.Core.Common;
using PensionGame.Core.Domain.Holdings;
using PensionGame.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionGame.Core.Calculators
{
    public interface IBondDefaultCalculator : ICalculator<BondDefaultRequiredData, IEither<BondHolding, BondDefaultEvent>>
    {
    }
}

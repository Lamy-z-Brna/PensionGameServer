using PensionGame.Core.Calculators.Common;
using PensionGame.Core.Calculators.RequiredData;
using PensionGame.Core.Domain.ClientData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionGame.Core.Calculators
{
    public interface IInvestmentSelectionValidationCalculator : IValidationCalculator<InvestmentSelectionValidationRequiredData, InvestmentSelection>
    {
    }
}

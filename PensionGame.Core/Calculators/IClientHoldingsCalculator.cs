using PensionGame.Core.Calculators.Common;
using PensionGame.Core.Calculators.RequiredData;
using PensionGame.Core.Domain.Holdings;

namespace PensionGame.Core.Calculators
{
    public interface IClientHoldingsCalculator : ICalculator<ClientHoldingsRequiredData, ClientHoldings>
    {
    }
}

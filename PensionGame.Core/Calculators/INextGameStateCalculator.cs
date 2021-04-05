using PensionGame.Core.Calculators.Common;
using PensionGame.Core.Calculators.RequiredData;
using PensionGame.Core.Domain.GameData;

namespace PensionGame.Core.Calculators
{
    public interface INextGameStateCalculator : ICalculator<NextGameStateRequiredData, GameState>
    {
    }
}

using PensionGame.Core.Calculators.Common;
using PensionGame.Core.Calculators.RequiredData;

namespace PensionGame.Core.Calculators.GameState
{
    public interface INextGameStateCalculator : ICalculator<NextGameStateRequiredData, Domain.GameData.GameState>
    {
    }
}

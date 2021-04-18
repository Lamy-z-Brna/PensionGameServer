using PensionGame.Core.Calculators.Common;
using PensionGame.Core.Events.PreReturnsEvents;
using System.Collections.Generic;

namespace PensionGame.Core.Calculators.Events
{
    public interface IPreReturnsEventCalculator : ICalculator<IReadOnlyCollection<IPreReturnsEvent>>
    {
    }
}

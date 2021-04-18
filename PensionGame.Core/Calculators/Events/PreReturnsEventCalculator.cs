using PensionGame.Core.Events.PreReturnsEvents;
using System;
using System.Collections.Generic;

namespace PensionGame.Core.Calculators.Events
{
    public sealed class PreReturnsEventCalculator : IPreReturnsEventCalculator
    {
        public IReadOnlyCollection<IPreReturnsEvent> Calculate()
        {
            return Array.Empty<IPreReturnsEvent>();
        }
    }
}

using PensionGame.Core.Events.PreReturnsEvents;
using System;
using System.Collections.Generic;

namespace PensionGame.Core.Calculators.Events
{
    public sealed class PreReturnsEventCalculator : IPreReturnsEventCalculator
    {
        public IReadOnlyCollection<PreReturnsEvent> Calculate()
        {
            return Array.Empty<PreReturnsEvent>();
        }
    }
}

using PensionGame.Core.Events.PreReturnsEvents;
using System;
using System.Collections.Generic;

namespace PensionGame.Core.Calculators
{
    public sealed class PreReturnsEventGenerator : IPreReturnsEventGenerator
    {
        public IReadOnlyCollection<IPreReturnsEvent> Generate()
        {
            return Array.Empty<IPreReturnsEvent>();
        }
    }
}

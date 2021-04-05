using PensionGame.Core.Events.PreReturnsEvents;
using System.Collections.Generic;
using System.Linq;

namespace PensionGame.Core.Calculators
{
    public sealed class PreReturnsEventGenerator : IPreReturnsEventGenerator
    {
        public IEnumerable<IPreReturnsEvent> Generate()
        {
            return Enumerable.Empty<IPreReturnsEvent>();
        }
    }
}

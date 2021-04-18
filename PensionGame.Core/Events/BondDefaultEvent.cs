using PensionGame.Core.Domain.Holdings;
using PensionGame.Core.Events.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionGame.Core.Events
{
    public record BondDefaultEvent(BondHolding BondHolding) : IEvent
    {
    }
}

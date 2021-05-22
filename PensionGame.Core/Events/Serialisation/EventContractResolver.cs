using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using PensionGame.Core.Events.Common;
using System;

namespace PensionGame.Core.Events.Serialisation
{
    public sealed class EventContractResolver : DefaultContractResolver
    {
        protected override JsonConverter? ResolveContractConverter(Type objectType)
        {
            if (typeof(Event).IsAssignableFrom(objectType) && !objectType.IsAbstract)
                return null; // pretend TableSortRuleConvert is not specified (thus avoiding a stack overflow)
            return base.ResolveContractConverter(objectType);
        }
    }
}

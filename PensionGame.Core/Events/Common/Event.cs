using PensionGame.Core.Events.Serialisation;
using System.Text.Json.Serialization;

namespace PensionGame.Core.Events.Common
{
    [JsonConverter(typeof(EventConverter))]
    public abstract record Event
    {
        public abstract EventType EventType { get; }
    }
}

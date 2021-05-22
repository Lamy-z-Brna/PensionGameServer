using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PensionGame.Core.Events.Common;
using PensionGame.Core.Events.PreClientDataEvents;
using PensionGame.Core.Events.PreMacroEconomicEvents;
using System;

namespace PensionGame.Core.Events.Serialisation
{
    public class EventConverter : JsonConverter
    {
        static JsonSerializerSettings SpecifiedSubclassConversion = new() { ContractResolver = new EventContractResolver() };

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Event);
        }

        public override object? ReadJson(JsonReader reader, Type objectType, object? existingValue, JsonSerializer serializer)
        {
            JObject jo = JObject.Load(reader);
            return Deserialise((EventType)jo["EventType"]!.Value<int>(), jo.ToString());
        }

        public static object? Deserialise(EventType eventType, string toDeserialise)
        {
            return eventType switch
            {
                EventType.AutomaticSavingsAccountInvestment => JsonConvert.DeserializeObject<AutomaticSavingsAccountInvestmentEvent>(toDeserialise, SpecifiedSubclassConversion),
                EventType.BondDefault => JsonConvert.DeserializeObject<BondDefaultEvent>(toDeserialise, SpecifiedSubclassConversion),
                EventType.Unemployment => JsonConvert.DeserializeObject<UnemploymentEvent>(toDeserialise, SpecifiedSubclassConversion),
                EventType.Crisis => JsonConvert.DeserializeObject<CrisisEvent>(toDeserialise, SpecifiedSubclassConversion),
                _ => throw new ArgumentOutOfRangeException(nameof(eventType))
            };
        }

        public override void WriteJson(JsonWriter writer, object? value, JsonSerializer serializer)
        {
            throw new NotImplementedException(); // won't be called because CanWrite returns false
        }

        public override bool CanWrite
        {
            get { return false; }
        }
    }
}

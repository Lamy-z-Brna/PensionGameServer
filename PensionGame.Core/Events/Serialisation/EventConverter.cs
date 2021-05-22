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
            switch ((EventType)jo["EventType"]!.Value<int>())
            {
                case EventType.AutomaticSavingsAccountInvestment:
                    return JsonConvert.DeserializeObject<AutomaticSavingsAccountInvestmentEvent>(jo.ToString(), SpecifiedSubclassConversion);
                case EventType.BondDefault:
                    return JsonConvert.DeserializeObject<BondDefaultEvent>(jo.ToString(), SpecifiedSubclassConversion);
                case EventType.Unemployment:
                    return JsonConvert.DeserializeObject<UnemploymentEvent>(jo.ToString(), SpecifiedSubclassConversion);
                case EventType.Crisis:
                    return JsonConvert.DeserializeObject<CrisisEvent>(jo.ToString(), SpecifiedSubclassConversion);
                case EventType.NotSpecified:
                    break;
                default:
                    throw new Exception();
            }
            throw new NotImplementedException();
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

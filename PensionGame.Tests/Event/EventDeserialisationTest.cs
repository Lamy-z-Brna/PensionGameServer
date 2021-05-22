using NUnit.Framework;
using PensionGame.Core.Events.Common;
using PensionGame.Core.Events.Serialisation;
using System;
using System.Linq;

namespace PensionGame.Tests.Event
{
    sealed class EventDeserialisationTest
    {
        [Test]
        public void AllEventsAreCovered()
        {
            try
            {
                Enum.GetValues(typeof(EventType))
                .Cast<EventType>()
                .Select(eventType => EventConverter.Deserialise(eventType, string.Empty))
                .ToList();
            }
            catch
            {
                Assert.Fail("All event types need to be successfully deserialised");
            }            
        }
    }
}

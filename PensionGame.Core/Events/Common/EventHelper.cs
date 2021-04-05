using System.Collections.Generic;
using System.Linq;

namespace PensionGame.Core.Events.Common
{
    public static class EventHelper
    {
        public static IEnumerable<T> GetEvents<T>(this IEnumerable<IEvent> events)
        {
            return events
                .Where(@event => @event is T)
                .Select(@event => (T)@event);
        }

        public static T? GetEvent<T>(this IEnumerable<IEvent> events)
        {
            return events
                .Where(@event => @event is T)
                .Select(@event => (T)@event)
                .FirstOrDefault();
        }

        public static bool AnyEvent<T>(this IEnumerable<IEvent> events)
        {
            return events
                .Where(@event => @event is T)
                .Any();
        }
    }
}

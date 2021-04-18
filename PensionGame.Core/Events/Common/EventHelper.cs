using System.Collections.Generic;
using System.Linq;

namespace PensionGame.Core.Events.Common
{
    public static class EventHelper
    {
        public static IReadOnlyCollection<T> GetEvents<T>(this IReadOnlyCollection<IEvent> events)
        {
            return events
                .Where(@event => @event is T)
                .Select(@event => (T)@event)
                .ToList();
        }

        public static T? GetEvent<T>(this IReadOnlyCollection<IEvent> events)
        {
            return events
                .Where(@event => @event is T)
                .Select(@event => (T)@event)
                .FirstOrDefault();
        }

        public static bool AnyEvent<T>(this IReadOnlyCollection<IEvent> events)
        {
            return events
                .Where(@event => @event is T)
                .Any();
        }
    }
}

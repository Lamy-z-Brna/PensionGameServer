using System.Collections.Generic;
using System.Linq;

namespace PensionGame.Core.Events.Common
{
    public static class EventHelper
    {
        public static IReadOnlyCollection<TOut> GetEvents<TIn, TOut>(this IReadOnlyCollection<TIn> events)            
            where TIn : Event
            where TOut : Event
        {
            return events
                .Where(@event => @event is TOut)
                .Select(@event => @event as TOut)
                .Select(@event => @event!)
                .ToList();
        }

        public static TOut? GetEvent<TIn, TOut>(this IReadOnlyCollection<TIn> events)
            where TIn : Event
            where TOut : Event
        {
            return events
                .Where(@event => @event is TOut)
                .Select(@event => @event as TOut)
                .Select(@event => @event!)
                .FirstOrDefault();
        }

        public static bool AnyEvent<T>(this IReadOnlyCollection<Event> events)
        {
            return events
                .Where(@event => @event is T)
                .Any();
        }
    }
}

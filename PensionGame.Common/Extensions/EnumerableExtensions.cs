using System.Collections.Generic;
using System.Linq;

namespace PensionGame.Common.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<(T item, int index)> WithIndex<T>(this IEnumerable<T> source, int firstIndex = 0)
        {
            return source.Select((item, index) => (item, index + firstIndex));
        }
    }
}

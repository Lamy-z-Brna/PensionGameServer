using PensionGame.Api.Common.Mappers;
using System.Collections.Generic;
using System.Linq;

namespace PensionGame.Api.Common.Helpers
{
    public static class MapperHelper
    {
        public static IEnumerable<TDest> Map<TSource, TDest>(this IMapper<TSource, TDest> mapper, IEnumerable<TSource> source)
        {
            return source.Select(mapper.Map).ToList();
        }
    }
}

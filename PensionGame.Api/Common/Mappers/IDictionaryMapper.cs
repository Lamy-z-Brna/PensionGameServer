using System.Collections.Generic;

namespace PensionGame.Api.Common.Mappers
{
    public interface IDictionaryMapper<TKey, TIn, TOut> : IMapper<Dictionary<TKey, TIn>, Dictionary<TKey, TOut>>
        where TKey: notnull
    {
    }
}

using System.Collections.Generic;
using System.Linq;

namespace PensionGame.Api.Common.Mappers
{
    public sealed class DictionaryMapper<TKey, TIn, TOut> : IDictionaryMapper<TKey, TIn, TOut>
        where TKey : notnull
    {
        private readonly IMapper<TIn, TOut> _mapper;

        public DictionaryMapper(IMapper<TIn, TOut> mapper)
        {
            _mapper = mapper;
        }

        public Dictionary<TKey, TOut> Map(Dictionary<TKey, TIn> dictionary)
        {
            return dictionary
                .Select(kv => new { kv.Key, Value = _mapper.Map(kv.Value) })
                .ToDictionary(kv => kv.Key, kv => kv.Value);
        }
    }
}

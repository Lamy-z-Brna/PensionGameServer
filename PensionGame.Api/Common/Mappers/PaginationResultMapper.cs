using PensionGame.Api.Common.Helpers;
using PensionGame.Api.Domain.Common;

namespace PensionGame.Api.Common.Mappers
{
    public sealed class PaginationResultMapper<TIn, TOut> : IPaginationResultMapper<TIn, TOut>
    {
        private readonly IMapper<TIn, TOut> _mapper;

        public PaginationResultMapper(IMapper<TIn, TOut> mapper)
        {
            _mapper = mapper;
        }

        public PaginationResult<TOut> Map(PaginationResult<TIn> source)
        {
            return new PaginationResult<TOut>
                (
                    Items: _mapper.Map(source.Items),
                    CurrentPage: source.CurrentPage,
                    CurrentItems: source.CurrentItems,
                    TotalItems: source.TotalItems,
                    TotalPages: source.TotalPages
                );
        }
    }
}

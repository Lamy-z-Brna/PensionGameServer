using PensionGame.Api.Domain.Common;

namespace PensionGame.Api.Common.Mappers
{
    public interface IPaginationResultMapper<TIn, TOut>: IMapper<PaginationResult<TIn>, PaginationResult<TOut>>
    {
    }
}

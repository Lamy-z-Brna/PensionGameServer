using System.Collections.Generic;

namespace PensionGame.Api.Domain.Common
{
    public record PaginationResult<T>(IEnumerable<T> Items, int CurrentPage, int CurrentItems, int TotalItems, int TotalPages)
    {
    }
}

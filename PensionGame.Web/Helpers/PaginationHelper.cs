using PensionGame.Api.Domain.Common;
using PensionGame.Common.Functional;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PensionGame.Web.Helpers
{
    public static class PaginationHelper
    {
        public static IReadOnlyCollection<Option<IReadOnlyCollection<int>>> ToPageNumbers<T>(this PaginatedCollection<T> paginatedCollection)
        {
            return GetPageNumbers(paginatedCollection.CurrentPage, paginatedCollection.TotalPages);
        }

        public static IReadOnlyCollection<Option<IReadOnlyCollection<int>>> GetPageNumbers(int currentPage, int totalPages)
        {
            var runningCollection = new List<int>();
            var finalCollection = new List<Option<IReadOnlyCollection<int>>>();

            foreach (var page in DivideIntoPages(currentPage, totalPages))
            {
                page.Do(
                    some => runningCollection.Add(some.Value),
                    none =>
                    {
                        finalCollection.Add(runningCollection);
                        finalCollection.Add(none);
                        runningCollection = new List<int>();
                    }
                    );
            }

            if (runningCollection.Any())
                finalCollection.Add(runningCollection);

            return finalCollection;
        }

        private static IEnumerable<Option<int>> DivideIntoPages(int currentPage, int totalPages)
        {
            var displayedPageNumbers = Enumerable.Range(1, totalPages)
                .Where(item =>
                    item == 1
                    || Math.Abs(item - currentPage) <= 1
                    || item == totalPages);

            var previousPageNumber = 1;

            foreach (var displayedNumber in displayedPageNumbers)
            {
                if (displayedNumber - previousPageNumber == 2)
                    yield return previousPageNumber + 1;

                if (displayedNumber - previousPageNumber > 2)
                    yield return Of.None;

                yield return displayedNumber;
                previousPageNumber = displayedNumber;
            }
        }
    }
}

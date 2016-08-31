using System.Collections.Generic;
using System.Linq;

namespace TH.Commons
{
    /// <summary>
    /// Reprezentuje listę zawierającą informacje o stronicowaniu.
    /// </summary>
    /// <typeparam name="T">Typ obiektu</typeparam>
    // ReSharper disable PossibleMultipleEnumeration
    public class PagedList<T> : List<T>, IPagedList<T>
    {
        /// <summary>
        /// Tworzy nową instancję klasy.
        /// </summary>
        /// <param name="source">Źródło listy</param>
        /// <param name="pageIndex">Bieżący indeks strony</param>
        /// <param name="pageSize">Ilość rekordów dla strony</param>
        public PagedList(IEnumerable<T> source, int pageIndex, int pageSize) :
            this(source, pageIndex, pageSize, source.Count())
        {
        }

        /// <summary>
        /// Tworzy nową instancję klasy.
        /// </summary>
        /// <param name="source">Źródło listy</param>
        /// <param name="pageIndex">Bieżący indeks strony</param>
        /// <param name="pageSize">Ilość rekordów dla strony</param>
        /// <param name="totalCount">Całkowita ilość rekordów obliczona wcześniej.</param>
        public PagedList(IEnumerable<T> source, int pageIndex, int pageSize, int totalCount)
        {
            TotalCount = totalCount;
            PageSize = pageSize;
            PageIndex = pageIndex;

            // ReSharper disable once PossibleLossOfFraction
            double pc = TotalCount / PageSize;
            if (TotalCount % PageSize > 0)
            {
                pc++;
            }
            TotalPages = (int)pc;

            HasPreviousPage = (PageIndex > 1);
            HasNextPage = (PageIndex * PageSize) < TotalCount;
            IsFirstPage = (PageIndex == 1);
            IsLastPage = (PageIndex == TotalPages);

            AddRange(source);
        }

        /// <summary>
        /// Zwraca całkowitą ilość stron.
        /// </summary>
        public int TotalPages { get; }

        /// <summary>
        /// Zwraca całkowitą ilość rekordów.
        /// </summary>
        public int TotalCount { get; }

        /// <summary>
        /// Zwraca indeks bieżącej strony.
        /// </summary>
        public int PageIndex { get; }

        /// <summary>
        /// Zwraca ustawioną ilość rekordów dla strony.
        /// </summary>
        public int PageSize { get; }

        /// <summary>
        /// Jeśli <c>true</c> to znaczy, że istnieje poprzednia strona, w przeciwnym wypadku <c>false</c>.
        /// </summary>
        public bool HasPreviousPage { get; }

        /// <summary>
        /// Jeśli <c>true</c> to znaczy, że istnieje następna strona, w przeciwnym wypadku <c>false</c>.
        /// </summary>
        public bool HasNextPage { get; }

        /// <summary>
        /// Jeśli <c>true</c> to znaczy, że jest to pierwsza strona, w przeciwnym wypadku <c>false</c>.
        /// </summary>
        public bool IsFirstPage { get; }

        /// <summary>
        /// Jeśli <c>true</c> to znaczy, że jest to ostatnia strona, w przeciwnym wypadku <c>false</c>.
        /// </summary>
        public bool IsLastPage { get; }
    }

    // ReSharper restore PossibleMultipleEnumeration
}
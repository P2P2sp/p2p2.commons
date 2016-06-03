using System.Collections.Generic;

namespace TH.Commons
{
    /// <summary>
    /// Definiuje listę zawierającą informacje o stronicowaniu.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPagedList<T> : ICollection<T>
    {
        /// <summary>
        /// Zwraca całkowitą ilość stron.
        /// </summary>
        int TotalPages { get; }

        /// <summary>
        /// Zwraca całkowitą ilość rekordów.
        /// </summary>
        int TotalCount { get; }

        /// <summary>
        /// Zwraca indeks bieżącej strony.
        /// </summary>
        int PageIndex { get; }
        
        /// <summary>
        /// Zwraca ustawioną ilość rekordów dla strony.
        /// </summary>
        int PageSize { get; }

        /// <summary>
        /// Jeśli <c>true</c> to znaczy, że istnieje poprzednia strona, w przeciwnym wypadku <c>false</c>.
        /// </summary>
        bool HasPreviousPage { get; }

        /// <summary>
        /// Jeśli <c>true</c> to znaczy, że istnieje następna strona, w przeciwnym wypadku <c>false</c>.
        /// </summary>
        bool HasNextPage { get; }


        /// <summary>
        /// Jeśli <c>true</c> to znaczy, że jest to pierwsza strona, w przeciwnym wypadku <c>false</c>.
        /// </summary>
        bool IsFirstPage { get; }

        /// <summary>
        /// Jeśli <c>true</c> to znaczy, że jest to ostatnia strona, w przeciwnym wypadku <c>false</c>.
        /// </summary>
        bool IsLastPage { get; }
    }
}
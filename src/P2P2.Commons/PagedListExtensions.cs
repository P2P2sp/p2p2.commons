using System.Collections.Generic;

namespace P2P2.Commons
{
    /// <summary>
    /// Rozszerza możliwości obiektów enumerycznych o stronicowanie.
    /// </summary>
    public static class PagedListExtensions
    {
        /// <summary>
        /// Przekształca w listę z informacją o stronicowaniu.
        /// </summary>
        /// <typeparam name="T">Typ obiektu</typeparam>
        /// <param name="source">Lista źródłowa</param>
        /// <param name="pageIndex">Indeks bieżącej strony</param>
        /// <param name="pageSize">Ilość rekordów dla strony</param>
        /// <returns>Lista z informacją o stronicowaniu.</returns>
        public static PagedList<T> ToPagedList<T>(this IEnumerable<T> source, int pageIndex, int pageSize)
        {
            return new PagedList<T>(source, pageIndex, pageSize);
        }

        /// <summary>
        /// Przekształca w listę z informacją o stronicowaniu.
        /// </summary>
        /// <typeparam name="T">Typ obiektu</typeparam>
        /// <param name="source">Lista źródłowa</param>
        /// <param name="pageIndex">Indeks bieżącej strony</param>
        /// <param name="pageSize">Ilość rekordów dla strony</param>
        /// <param name="totalCount">Całkowita ilość rekordów obliczona wcześniej.</param>
        /// <returns>Lista z informacją o stronicowaniu.</returns>
        public static IPagedList<T> ToPagedList<T>(this IEnumerable<T> source, int pageIndex, int pageSize, int totalCount)
        {
            return new PagedList<T>(source, pageIndex, pageSize, totalCount);
        }
    }
}
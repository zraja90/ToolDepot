using System.Collections.Generic;
using PagedList;

namespace ToolDepot.Helpers
{
    public static partial class PageListHelper
    {

        public static IPagedList<T> ToPagedList<T>(this IEnumerable<T> subSet, int pageNumber, int pageSize, int totalItemCount)
        {
            return (IPagedList<T>)new StaticPagedList<T>(subSet, pageNumber, pageSize, totalItemCount);
        }

    }
}
using System.Collections.Generic;
using System.Linq;

namespace NInfra.LinqExtensions.Search
{
    public static class SearchExtensions
    {
        public static IEnumerable<TSource> Search<TSource>(this IEnumerable<TSource> sources, params SearchExpression[] expressions)
        {
            throw new System.NotImplementedException();
        }

        public static IQueryable<TSource> Search<TSource>(this IQueryable<TSource> sources, params SearchExpression[] expressions)
        {
            throw new System.NotImplementedException();
        }
    }
}

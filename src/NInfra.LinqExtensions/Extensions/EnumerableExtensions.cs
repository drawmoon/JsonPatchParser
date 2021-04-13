using NInfra.LinqExtensions.Internal;
using NInfra.LinqExtensions.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace NInfra.LinqExtensions.Extensions
{
    public static class EnumerableExtensions
    {
        #region SortBy
        public static IEnumerable<TSource> SortBy<TSource>(this IEnumerable<TSource> sources,
            params SortByExpression[] expressions) => sources.SortBy(action: null, expressions);

        public static IEnumerable<TSource> SortBy<TSource>(this IEnumerable<TSource> sources, Dictionary<string, string> subs, params SortByExpression[] expressions)
        {
            void Prepare(SortByExpression expression)
            {
                if (subs.TryGetValue(expression.Left, out var val))
                    expression.Left = val;
            }

            return sources.SortBy(Prepare, expressions);
        }

        private static IEnumerable<TSource> SortBy<TSource>(this IEnumerable<TSource> sources, Action<SortByExpression>? action, params SortByExpression[] expressions)
        {
            var sourceType = typeof(TSource);
            var parameterExpression = Expression.Parameter(sourceType);

            var orderedEnumerable = sources;
            foreach (var expression in expressions)
            {
                var op = expression.Op;
                if (op == SortOperator.None)
                    continue;

                action?.Invoke(expression);

                var keySelector = ExpressionUtilities.BuildKeySelector<TSource>(parameterExpression, expression.Left).Compile();
                orderedEnumerable = op == SortOperator.Asc
                    ? sources.OrderBy(keySelector)
                    : sources.OrderByDescending(keySelector);
            }

            return orderedEnumerable;
        }
        #endregion

        #region Search
        public static IEnumerable<TSource> Search<TSource>(this IEnumerable<TSource> sources, params SearchExpression[] expressions)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}

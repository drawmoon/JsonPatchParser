using System;
using System.Linq.Expressions;

namespace NInfra.LinqExtensions.Internal
{
    internal static class ExpressionUtilities
    {
        internal static Expression<Func<TSource, object>> BuildKeySelector<TSource>(ParameterExpression parameterExpression, string propertyName)
        {
            var property = Expression.Property(parameterExpression, propertyName);
            var body = Expression.Convert(property, typeof(object));
            return Expression.Lambda<Func<TSource, object>>(body, parameterExpression);
        }
    }
}
using System;
using System.Linq;
using System.Linq.Expressions;

namespace RelationApp.Core.Shared
{
    public static class SortingDynamic
    {
        /// <summary>
        /// Add to received <paramref name="query"/> Linq Method for Ordering by ascending or descending (depends on <paramref name="descending"/>).
        /// </summary>
        /// <typeparam name="Relation"></typeparam>
        /// <param name="query"></param>
        /// <param name="propertyForSorting"></param>
        /// <param name="descending"></param>
        /// <returns></returns>
        public static IOrderedQueryable<Relation> SortDynamically<Relation>(IQueryable<Relation> query, string propertyForSorting, bool descending)
        {
            string propertyValidForSorting = string.IsNullOrEmpty(propertyForSorting) ? "Name" : propertyForSorting;

            Expression<Func<IOrderedQueryable<Relation>>> methodToSort;
            MemberExpression propertyForLambdaExpression;

            var parameter = Expression.Parameter(typeof(Relation), "relation");

            if (typeof(Relation).GetProperty(propertyValidForSorting) == null)
            {
                var propertyRelationAddress = Expression.PropertyOrField(parameter, typeof(Relation).GetProperty("RelationAddress").Name);
                propertyForLambdaExpression = Expression.PropertyOrField(propertyRelationAddress, propertyValidForSorting);
            }
            else
            {
                propertyForLambdaExpression = Expression.PropertyOrField(parameter, propertyValidForSorting);
            }

            var lambdaExpressionToSort = Expression.Lambda(propertyForLambdaExpression, parameter);

            if (descending)
            {
                methodToSort = () => query.OrderByDescending<Relation, object>(r => null);
            }
            else
            {
                methodToSort = () => query.OrderBy<Relation, object>(r => null);
            }

            var methodCallExpression = methodToSort.Body as MethodCallExpression;

            var method = methodCallExpression.Method.GetGenericMethodDefinition();
            var genericSortMethod = method.MakeGenericMethod(typeof(Relation), propertyForLambdaExpression.Type);
            var orderedQuery = (IOrderedQueryable<Relation>)genericSortMethod.Invoke(query, new object[] { query, lambdaExpressionToSort });

            return orderedQuery;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;

namespace tcc1_api.Extensions
{
    public static class SortingExtensions
    {
        public static IQueryable<T> ApplySort<T>(this IQueryable<T> query, string sortBy, bool isDescending)
        {
            if (string.IsNullOrEmpty(sortBy))
            {
                return query;
            }

            var property = typeof(T).GetProperty(sortBy, 
                BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            
            if (property == null)
            {
                return query; 
            }

            var parameter = Expression.Parameter(typeof(T), "x");
            var propertyAccess = Expression.MakeMemberAccess(parameter, property);
            var lambda = Expression.Lambda(propertyAccess, parameter);
            
            var methodName = isDescending ? "OrderByDescending" : "OrderBy";
            var resultExp = Expression.Call(typeof(Queryable), methodName,
                new Type[] { typeof(T), property.PropertyType },
                query.Expression, Expression.Quote(lambda));
                
            return query.Provider.CreateQuery<T>(resultExp);
        }
    }
}
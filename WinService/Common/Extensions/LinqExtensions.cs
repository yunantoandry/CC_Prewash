using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Common.Extensions
{
    public static class LinqExtensions
    {
        /// <summary>
        /// If a string is not null of whitespace, apply a Where predicate.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="queryable"></param>
        /// <param name="str"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static IQueryable<T> WhereIfAny<T>(this IQueryable<T> queryable, string str, Expression<Func<T, bool>> predicate)
        {
            if (str.IsNotWhitespace())
            {
                return queryable.Where(predicate);
            }
            else
            {
                return queryable;
            }
        }
        
        public static Queue<T> ToQueue<T>(this IEnumerable<T> enumerable)
        {
            var queue = new Queue<T>();

            foreach(var item in enumerable)
            {
                queue.Enqueue(item);
            }

            return queue;
        }
    }
}

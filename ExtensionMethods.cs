using System;
using System.Collections.Generic;
using System.Linq;

namespace Homework7
{
    public static class ExtensionMethods
    {
        public static IEnumerable<TResult> ExtensionSelect<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            return new EnumerableSW<TSource, TResult>(source, selector,null);
        }

        public static IEnumerable<TSource> ExtensionWhere<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            return new EnumerableSW<TSource, TSource>(source, null, predicate);
        }

        public static IEnumerable<IGrouping<TKey, TSource>> ExtensionGroupBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            return new GroupingEnumerable<TSource, TKey>(source, keySelector);
        }


        public static List<TSource> ExtensionToList<TSource>(this IEnumerable<TSource> source)
        {
            List<TSource> list = new List<TSource>();
            foreach (var element in source)
            {
                list.Add(element);
            }
            return list;
        }

        public static IOrderedEnumerable<TSource> ExtensionOrderBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, bool descending)
        {
            return new OrderEnumerable<TSource, TKey>(source, keySelector, default(IComparer<TKey>), descending);
        }

        public static Dictionary<TKey, TSource> ExtensionToDictionary<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            Dictionary<TKey, TSource> dictionary = new Dictionary<TKey, TSource>();
            foreach (var element in source)
            {
                dictionary.Add(keySelector(element), element);
            }
            return dictionary;
        }
    }
}

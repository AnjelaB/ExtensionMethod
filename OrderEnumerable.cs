using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework7
{
    class OrderEnumerable<TSource,TKey> : IOrderedEnumerable<TSource>
    {
        private IEnumerable<TSource> source;
        private List<TSource> list;

        public IOrderedEnumerable<TSource> CreateOrderedEnumerable<TKey>(Func<TSource, TKey> keySelector, IComparer<TKey> comparer, bool descending)
        {
            return new OrderEnumerable<TSource, TKey>(source, keySelector, comparer, descending);
        }

        public OrderEnumerable(IEnumerable<TSource> source, Func<TSource,TKey> keySelector, IComparer<TKey> comparer, bool descending)
        {
            this.source = source;
            this.list = new List<TSource>();
            if (descending)
            {
                foreach (var element in source)
                {
                    if (list == null)
                    {
                        list.Add(element);
                    }

                    for (int i = 0; i < list.Count; i++)
                    {
                        if (comparer.Compare(keySelector(element), keySelector(list[i])) > 0)
                        {
                            list.Insert(i, element);

                        }
                    }
                }
            }
            else
            {
                foreach (var element in source)
                {
                    if (list == null)
                    {
                        list.Add(element);
                    }

                    for (int i = 0; i < list.Count; i++)
                    {
                        if (comparer.Compare(keySelector(element), keySelector(list[i])) < 0)
                        {
                            list.Insert(i, element);

                        }
                    }
                }
            }
        }
        public IEnumerator<TSource> GetEnumerator()
        {
            return list.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return list.GetEnumerator();
        }
    }
}

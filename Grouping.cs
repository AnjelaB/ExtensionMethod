using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Homework7
{
    public class Grouping<TKey, TSource> : IGrouping<TKey, TSource>
    {
        private readonly TKey key;
        private readonly IEnumerable<TSource> values;

        public Grouping(IEnumerable<TSource> source, Func<TSource, TKey> keySelector, TKey key)
        {
            this.key = key;
            this.values = ExtensionMethods.ExtensionWhere<TSource>(this.values, select => keySelector(select).Equals(this.key));

        }

        public TKey Key
        {
            get { return key; }
        }

        public IEnumerator<TSource> GetEnumerator()
        {
            return values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return values.GetEnumerator();
        }
    }
}

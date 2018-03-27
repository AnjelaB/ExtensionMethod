using System;
using System.Collections;
using System.Collections.Generic;

namespace Homework7
{
    class GroupingEnumerable<TSource, TKey> : IEnumerable<Grouping<TKey, TSource>>
    {
        private IEnumerable<TSource> source;
        private Func<TSource, TKey> keySelector;

        public GroupingEnumerable(IEnumerable<TSource> source, Func<TSource,TKey> keySelector)
        {
            this.source = source;
            this.keySelector = keySelector;
        }

        public IEnumerator<Grouping<TKey, TSource>> GetEnumerator()
        {
            return new GroupingEnumerator<TSource, TKey>(this.source, this.keySelector);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new GroupingEnumerator<TSource, TKey>(this.source, this.keySelector);
        }
    }
}

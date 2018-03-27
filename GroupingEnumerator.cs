using System;
using System.Collections;
using System.Collections.Generic;

namespace Homework7
{
    public class GroupingEnumerator<TSource, TKey> : IEnumerator<Grouping<TKey, TSource>>
    {
        List<Grouping<TKey, TSource>> groups;
        List<TKey> keys;
        private Grouping<TKey, TSource> current;

        public Grouping<TKey, TSource> Current
        {
            get
            {
                return this.current;
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return this.current;
            }
        }

        public GroupingEnumerator(IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            this.keys = new List<TKey>();
            TKey key;
            foreach (var element in source)
            {
                key = keySelector(element);
                if (!keys.Contains(key))
                {
                    this.groups.Add(new Grouping<TKey, TSource>(source, keySelector, key));
                    this.keys.Add(key);
                }
            }
        }

        public void Dispose()
        {
            return;
        }

        public bool MoveNext()
        {
            this.groups.GetEnumerator().MoveNext();
            if (this.keys.GetEnumerator().MoveNext())
            {
                current = groups.GetEnumerator().Current;
                return true;
            }
            return false;

        }

        public void Reset()
        {
            IEnumerator<TKey> k = keys.GetEnumerator();
            k.Reset();
            IEnumerator<Grouping<TKey, TSource>> g = groups.GetEnumerator();
            g.Reset();
        }
    }

    
}

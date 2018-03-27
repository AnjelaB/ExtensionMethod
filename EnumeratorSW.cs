using System;
using System.Collections;
using System.Collections.Generic;

namespace Homework7
{
    /// <summary>
    /// Enumerator for elements either of TResult type or of TSource type.
    /// </summary>
    /// <typeparam name="TSource"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    class EnumeratorSW<TSource, TResult> : IEnumerator<TResult>
    {
        private IEnumerable<TSource> source;
        private Func<TSource, TResult> selector;
        private Func<TSource, bool> predicate;
        private Func<bool> moveNext;
        private dynamic current;
        private IEnumerator<TSource> sourceEnumerator;

        public TResult Current
        {
            get
            {
                return current;
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return current;
            }
        }

        public EnumeratorSW(IEnumerable<TSource> source,Func<TSource,TResult> selector,Func<TSource, bool> predicate)
        {
            this.source = source;
            if (selector != null)
            {
                moveNext = MoveNextForSelector;
                this.selector = selector;
            }
            else
            {
                moveNext = MoveNextForPredicate;
                this.predicate = predicate;
            }
            this.sourceEnumerator = source.GetEnumerator();
        }

        public void Dispose()
        {
            return;
        }

        private bool MoveNextForSelector()
        {
            if(this.sourceEnumerator.MoveNext())
            {
                current = selector(this.sourceEnumerator.Current);
                return true;
            }

            return false;
        }

        private bool MoveNextForPredicate()
        {
            bool boolean = this.sourceEnumerator.MoveNext();
            if (!boolean)
                return false;
            while (!this.predicate(this.sourceEnumerator.Current))
            {

                boolean = this.sourceEnumerator.MoveNext();
                if (!boolean)
                    return false;
            }
            this.current = this.sourceEnumerator.Current;
            return true;
        }
        public bool MoveNext()
        {
            if (moveNext())
                return true;
            else
                return false;
        }

        public void Reset()
        {
            sourceEnumerator.Reset();
            current = sourceEnumerator.Current;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;

namespace Homework7
{
    /// <summary>
    /// Class for enumerating either results of selector or sources satisfied an predicate.
    /// </summary>
    /// <typeparam name="TSource">Type  of source.</typeparam>
    /// <typeparam name="TResult">Type of result.</typeparam>
    class EnumerableSW<TSource, TResult> : IEnumerable<TResult>
    {
        /// <summary>
        /// Source that will be used.
        /// </summary>
        private readonly IEnumerable<TSource> source;

        /// <summary>
        /// Selector for every element of TSource type , that return element of TResult type.
        /// </summary>
        private Func<TSource, TResult> selector;

        /// <summary>
        /// Predicate that get element of TSource type and return either true or false.
        /// </summary>
        private Func<TSource,bool> predicate;

        /// <summary>
        /// Parametrised  constructor that get either selector or prdedicate.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <param name="predicate"></param>
        public EnumerableSW(IEnumerable<TSource> source, Func<TSource,TResult> selector, Func<TSource,bool> predicate)
        {
            this.source = source;
            this.selector = selector;
            this.predicate = predicate;
        }

        public IEnumerator<TResult> GetEnumerator()
        {
            return new EnumeratorSW<TSource,TResult>(source, selector, predicate);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new EnumeratorSW<TSource, TResult>(source, selector, predicate);
        }
    }
}

using System;
using System.Collections.Generic;

namespace Avalon.Core.Extensions
{
    /// <summary>
    /// Enumerable extensions.  Provides a ForEach + linq mechanism for Generics
    /// that don't have that support already, such as Dictionary.
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// For instance, a Dictionary&lt;int, string&gt; foo, you can do
        /// foo.ForEach((i) => Console.WriteLine(i.Value));
        /// </summary>
        /// <param name='enumerable'>
        /// Enumerable.
        /// </param>
        /// <param name='action'>
        /// Action.
        /// </param>
        /// <typeparam name='T'>
        /// The 1st type parameter.
        /// </typeparam>
        public static void ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (T item in enumerable) action.Invoke(item);
        }
    }
}

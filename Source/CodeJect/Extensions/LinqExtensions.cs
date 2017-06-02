using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeJect
{
    public static class LinqExtensions
    {
        public static IEnumerable<T> Do<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var item in source)
            {
                action(item);

                yield return item;
            }
        }

        public static void ForeEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            foreach (var item in source)
            {
                action(item);
            }
        }

        public static bool None<T>(this IEnumerable<T> source) 
            => !source.Any();

        public static bool None<T>(this IEnumerable<T> source, Func<T, bool> predicate)
            => !source.Any(predicate);

        public static ISet<TOutput> ToHashSet<TInput, TOutput>(this IEnumerable<TInput> source, Func<TInput, TOutput> selector)
            => new HashSet<TOutput>(source.Select(selector));

        public static ISet<T> ToHashSet<T>(this IEnumerable<T> source)
            => source.ToHashSet(t => t);
    }
}

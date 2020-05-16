using System;
using System.Collections.Generic;
using System.Linq;

namespace GF.Couno.CardGameProtoWpf
{
    public static class EnumerableExtensions
    {
        #region - Methoden oeffentlich -

        public static IEnumerable<IEnumerable<T>> CartesianProduct<T>
            (this IEnumerable<IEnumerable<T>> sequences)
        {
            IEnumerable<IEnumerable<T>> emptyProduct =
                new[] {Enumerable.Empty<T>()};
            var result = emptyProduct;
            foreach (var sequence in sequences)
            {
                result = from accseq in result from item in sequence select accseq.Concat(new[] {item});
            }

            return result;
        }

        /// <summary>
        ///     Fügt eine Menge von Elementen in die IList ein
        /// </summary>
        /// <typeparam name="T">Elementtyp</typeparam>
        /// <param name="list">Liste</param>
        /// <param name="items">Neue Elemente</param>
        public static void AddRange<T>(this IList<T> list, IEnumerable<T> items)
        {
            foreach (var item in items)
            {
                list.Add(item);
            }
        }

        public static T[] YieldToArray<T>(this T singleElement)
        {
            return new T[1] {singleElement};
        }

        public static IEnumerable<T> PickRandom<T>(this IEnumerable<T> source, int count) => source.Shuffle().Take(count);

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source) => source.Shuffle(RandomExtensions.ThisThreadsRandom);

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, Random rng)
        {
            if (source == null)
            {
                throw new ArgumentNullException("source");
            }

            if (rng == null)
            {
                throw new ArgumentNullException("rng");
            }

            return source.ShuffleIterator(rng);
        }

        public static IEnumerable<T> Yield<T>(this T singleElement, params T[] otherElements)
        {
            return new[] {singleElement}.Concat(otherElements);
        }

        public static IEnumerable<T> YieldIfNotNull<T>(this T singleElement)
        {
            if (singleElement != null)
            {
                return new[] {singleElement};
            }

            return Enumerable.Empty<T>();
        }

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source) => source == null || !source.Any();

        public static bool IsEmpty<T>(this IEnumerable<T> source) => !source.Any();

        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            if (source == null)
            {
                return;
            }

            foreach (var obj in source)
            {
                action(obj);
            }
        }

        public static void ForEach<T>(this IEnumerable<T> source, Action<T, int> action)
        {
            if (source == null)
            {
                return;
            }

            var num = 0;
            foreach (var obj in source)
            {
                action(obj, num++);
            }
        }

        public static void ForEach<TFirst, TSecond>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second,
            Action<TFirst, TSecond> action)
        {
            using (var enumerator1 = first.GetEnumerator())
            {
                using (var enumerator2 = second.GetEnumerator())
                {
                    while (enumerator1.MoveNext() && enumerator2.MoveNext())
                    {
                        action(enumerator1.Current, enumerator2.Current);
                    }
                }
            }
        }

        #endregion

        #region - Methoden privat -

        private static IEnumerable<T> ShuffleIterator<T>(
            this IEnumerable<T> source, Random rng)
        {
            var buffer = source.ToList();
            for (var i = 0; i < buffer.Count; i++)
            {
                var j = rng.Next(i, buffer.Count);
                yield return buffer[j];
                buffer[j] = buffer[i];
            }
        }

        #endregion
    }
}
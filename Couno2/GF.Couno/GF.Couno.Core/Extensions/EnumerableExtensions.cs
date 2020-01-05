using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace GF.Couno.Core.Extensions
{
    internal static class EnumerableExtensions
    {
        #region - Methoden oeffentlich -

        public static IEnumerable<IEnumerable<T>> CartesianProduct<T>
            (this IEnumerable<IEnumerable<T>> sequences)
        {
            IEnumerable<IEnumerable<T>> emptyProduct =
                new[] { Enumerable.Empty<T>() };
            IEnumerable<IEnumerable<T>> result = emptyProduct;
            foreach (IEnumerable<T> sequence in sequences)
            {
                result = from accseq in result from item in sequence select accseq.Concat(new[] {item});
            }
            return result;
        }

        /// <summary>
        /// Fügt eine Menge von Elementen in die IList ein
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

        public static IEnumerable<TSource> Do<TSource>(this IEnumerable<TSource> source, Action<TSource> action)
        {
            foreach (var entry in source)
            {
                action?.Invoke(entry);
            }

            return source;
        }

        /// <summary>
        /// Entfernt alle Einträge aus einer Aufzählung, die vom Typ TK sind.
        /// </summary>
        /// <typeparam name="T">Typ</typeparam>
        /// <typeparam name="TK">Typ der Elemente die entfernt werden sollen</typeparam>
        /// <param name="source">Aufzählung</param>
        /// <returns>Aufzählung ohne Elemente vom Typ TK</returns>
        public static IEnumerable<T> NotOfType<T, TK>( this IEnumerable<T> source) where TK : class, T where T : class
        {
            return source.Where(item => !(item is TK));
        }

        public static T[] YieldToArray<T>(this T singleElement)
        {
            return new T[1] { singleElement };
        }

        /// <summary>
        /// Checks whether a collection is the same as another collection.
        /// </summary>
        /// <param name="listA">The list A.</param>
        /// <param name="listB">The list B.</param>
        /// <returns>
        /// True if the two collections contain all the same items in the same order.
        /// </returns>
        public static bool IsEqualTo(IEnumerable listA, IEnumerable listB)
        {
            if (ReferenceEquals(listA, listB))
            {
                return true;
            }

            if (listA == listB)
            {
                return true;
            }

            if (listA == null || listB == null)
            {
                return false;
            }

            var enumeratorA = listA.GetEnumerator();
            var enumeratorB = listB.GetEnumerator();

            var enumAHasValue = enumeratorA.MoveNext();
            var enumBHasValue = enumeratorB.MoveNext();

            while (enumAHasValue && enumBHasValue)
            {
                var currentA = enumeratorA.Current;
                var currentB = enumeratorB.Current;

                if (currentA == currentB)
                {
                    enumAHasValue = enumeratorA.MoveNext();
                    enumBHasValue = enumeratorB.MoveNext();

                    continue;
                }

                if (!ObjectExtensions.AreEqual(currentA, currentB))
                {
                    return false;
                }

                enumAHasValue = enumeratorA.MoveNext();
                enumBHasValue = enumeratorB.MoveNext();
            }

            // If we get here, and both enumerables don't have any value left, they are equal
            return !(enumAHasValue || enumBHasValue);
        }

        public static IEnumerable<T> PickRandom<T>(this IEnumerable<T> source, int count)
        {
            return source.Shuffle().Take(count);
        }

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
        {
            return source.Shuffle(new Random());
        }

        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source, Random rng)
        {
            if (source == null) throw new ArgumentNullException("source");
            if (rng == null) throw new ArgumentNullException("rng");

            return source.ShuffleIterator(rng);
        }

        private static IEnumerable<T> ShuffleIterator<T>(
            this IEnumerable<T> source, Random rng)
        {
            var buffer = source.ToList();
            for (int i = 0; i < buffer.Count; i++)
            {
                int j = rng.Next(i, buffer.Count);
                yield return buffer[j];

                buffer[j] = buffer[i];
            }
        }

        public static IEnumerable<T> Yield<T>(this T singleElement)
        {
            return new[] { singleElement };
        }

        public static IEnumerable<T> YieldIfNotNull<T>(this T singleElement)
        {
            if (singleElement != null)
            {
                return new[] { singleElement };
            }
            return Enumerable.Empty<T>();
        }

        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
        {
            return source == null || !source.Any();
        }
        
        public static IEnumerable<T> DistinctBy<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector)
        {
            return source.DistinctBy(keySelector, null);
        }
        
        public static IEnumerable<T> DistinctBy<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector, IEqualityComparer<TKey> comparer) 
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (keySelector == null) throw new ArgumentNullException(nameof(keySelector));

            return _();

            IEnumerable<T> _()
            {
                var knownKeys = new HashSet<TKey>(comparer);
                foreach (var element in source)
                {
                    if (knownKeys.Add(keySelector(element)))
                        yield return element;
                }
            }
        }

        public static bool IsEmpty<T>(this IEnumerable<T> source)
        {
            return !source.Any();
        }

        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            if (source == null)
            {
                return;
            }

            foreach (T obj in source)
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

            int num = 0;
            foreach (T obj in source)
            {
                action(obj, num++);
            }
        }

        public static void ForEach<TFirst, TSecond>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second, Action<TFirst, TSecond> action)
        {
            using (IEnumerator<TFirst> enumerator1 = first.GetEnumerator())
            {
                using (IEnumerator<TSecond> enumerator2 = second.GetEnumerator())
                {
                    while (enumerator1.MoveNext() && enumerator2.MoveNext())
                    {
                        action(enumerator1.Current, enumerator2.Current);
                    }
                }
            }
        }

        public static IEnumerable<T> Unfold<T>(T seed, Func<T, T> next, Func<T, bool> stop)
        {
            for (T current = seed; !stop(current); current = next(current))
            {
                yield return current;
            }
        }

        public static IEnumerable<T> Flatten<T>(this IEnumerable<T> source, Func<T, IEnumerable<T>> getItems)
        {
            return source.SelectMany<T, T>((Func<T, IEnumerable<T>>)(item => item.Yield<T>().Concat<T>(getItems(item).Flatten<T>(getItems))));
        }

        public static T MinBy<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector) where TKey : IComparable
        {
            Comparer<TKey> comparer = Comparer<TKey>.Default;
            return source.Aggregate<T>((Func<T, T, T>)((x, y) =>
            {
                if (comparer.Compare(keySelector(x), keySelector(y)) >= 0)
                {
                    return y;
                }
                return x;
            }));
        }

        public static T MaxBy<T, TKey>(this IEnumerable<T> source, Func<T, TKey> keySelector) where TKey : IComparable
        {
            Comparer<TKey> comparer = Comparer<TKey>.Default;
            return source.Aggregate<T>((Func<T, T, T>)((x, y) =>
            {
                if (comparer.Compare(keySelector(x), keySelector(y)) <= 0)
                {
                    return y;
                }
                return x;
            }));
        }

        public static IEnumerable<T> InsertDelimeter<T>(this IEnumerable<T> source, T delimeter)
        {
            using (IEnumerator<T> en = source.GetEnumerator())
            {
                if (en.MoveNext())
                {
                    yield return en.Current;
                }

                while (en.MoveNext())
                {
                    yield return delimeter;
                    yield return en.Current;
                }
            }
        }

        public static IOrderedEnumerable<TSource> OrderBy<TSource, TKey>(
            this IEnumerable<TSource> source,
            Func<TSource, TKey> keySelector,
            ListSortDirection sortDirection)
        {
            if (sortDirection != ListSortDirection.Ascending)
            {
                return source.OrderByDescending<TSource, TKey>(keySelector);
            }
            return source.OrderBy<TSource, TKey>(keySelector);
        }

        public static Func<T> Memoize<T>(this Func<T> getValue)
        {
            Lazy<T> lazy = new Lazy<T>(getValue);
            return (Func<T>)(() => lazy.Value);
        }

        /// <summary>
        /// Liefert das erste Element einer Aufzählung zurück. Falls kein Element gefunden wird, wird ein
        /// leeres, d.h. neues Objekt der Klasse zurückgegeben.
        /// </summary>
        /// <typeparam name="T">Typ</typeparam>
        /// <param name="source">Aufzählung</param>
        /// <returns>Erstes Element der Aufzählung oder ein neues Element vom Typ falls die Aufzählung leer ist</returns>
        public static T FirstOrEmpty<T>(this IEnumerable<T> source) where T : class, new()
        {
            return source.FirstOrDefault() ?? new T();
        }

        /// <summary>
        /// Liefert das erste Element einer Aufzählung für das das Prädikat wahr wird zurück. Falls kein Element gefunden wird, wird ein
        /// leeres, d.h. neues Objekt der Klasse zurückgegeben.
        /// </summary>
        /// <typeparam name="T">Typ</typeparam>
        /// <param name="source">Aufzählung</param>
        /// <param name="predicate">Prädikat</param>
        /// <returns>Erstes Element der Aufzählung oder ein neues Element vom Typ falls die Aufzählung leer ist oder das Prädikat immer false zurückliefert</returns>
        public static T FirstOrEmpty<T>(this IEnumerable<T> source, Func<T, bool> predicate) where T : class, new()
        {
            return source.FirstOrDefault(predicate) ?? new T();
        }

        /// <summary>
        /// Liefert das letzte Element einer Aufzählung zurück. Falls kein Element gefunden wird, wird ein
        /// leeres, d.h. neues Objekt der Klasse zurückgegeben.
        /// </summary>
        /// <typeparam name="T">Typ</typeparam>
        /// <param name="source">Aufzählung</param>
        /// <returns>Letztes Element der Aufzählung oder ein neues Element vom Typ falls die Aufzählung leer ist</returns>
        public static T LastOrEmpty<T>(this IEnumerable<T> source) where T : class, new()
        {
            return source.LastOrDefault() ?? new T();
        }


        /// <summary>
        /// Liefert das letzte Element einer Aufzählung für das das Prädikat wahr wird zurück. Falls kein Element gefunden wird, wird ein
        /// leeres, d.h. neues Objekt der Klasse zurückgegeben.
        /// </summary>
        /// <typeparam name="T">Typ</typeparam>
        /// <param name="source">Aufzählung</param>
        /// <param name="predicate">Prädikat</param>
        /// <returns>Letztes Element der Aufzählung oder ein neues Element vom Typ falls die Aufzählung leer ist oder das Prädikat immer false zurückliefert</returns>
        public static T LastOrEmpty<T>(this IEnumerable<T> source, Func<T, bool> predicate) where T : class, new()
        {
            return source.LastOrDefault(predicate) ?? new T();
        }

        public static Action CombineActions(params Action[] actions)
        {
            return (Action)(() => ((IEnumerable<Action>)actions).ForEach<Action>((Action<Action>)(x => x())));
        }

        /// <summary>
        /// Führt eine Factory auf eine Eingabeaufzählung aus.
        /// Dabei wird die Eingabeaufzählung in 100er-Teile zerlegt und für jede 100er-Liste wird dann die Factory aufgerufen.
        /// </summary>
        /// <typeparam name="TInput">Eingabetyp, z.B. PrimaryKey</typeparam>
        /// <typeparam name="TResult">Ausgabetyp, z.B. konkreter jtlObject-Typ</typeparam>
        /// <param name="source">Eingabeaufzählung</param>
        /// <param name="fFactory">Factory, die aus den Eingabetypen Ausgabetypen macht z.B. FindComplete-Methode</param>
        /// <returns>Aufzählung mit allen Elementen</returns>
        public static IEnumerable<TResult> FactorizeInSetsOf<TInput, TResult>(this IEnumerable<TInput> source, Func<IEnumerable<TInput>, IEnumerable<TResult>> fFactory)
        {
            return source.InSetsOf().SelectMany(set => fFactory(set));
        }

        /// <summary>
        /// Führt eine Factory auf eine Eingabeaufzählung aus.
        /// Dabei wird die Eingabeaufzählung in 100er-Teile zerlegt und für jede 100er-Liste wird dann die Factory aufgerufen.
        /// </summary>
        /// <typeparam name="TInput">Eingabetyp, z.B. PrimaryKey</typeparam>
        /// <typeparam name="TResult">Ausgabetyp, z.B. konkreter jtlObject-Typ</typeparam>
        /// <param name="source">Eingabeaufzählung</param>
        /// <param name="fFactory">Factory, die aus den Eingabetypen Ausgabetypen macht z.B. FindComplete-Methode</param>
        /// <param name="max">Anzahl der Elemente in einer Teilliste</param>
        /// <returns>Aufzählung mit allen Elementen</returns>
        public static IEnumerable<TResult> FactorizeInSetsOf<TInput, TResult>(this IEnumerable<TInput> source, Func<IEnumerable<TInput>, IEnumerable<TResult>> fFactory, int max)
        {
            return source.InSetsOf(max).SelectMany(set => fFactory(set));
        }

        /// <summary>
        /// Zerlegt die Aufzählung in Listen aus maximal max Elementen.
        /// </summary>
        /// <typeparam name="T">Typ</typeparam>
        /// <param name="source">Aufzählung</param>
        /// <param name="max">Anzahl der Elemnte in einer Teilliste</param>
        /// <returns>Aufzählung von Teillisten</returns>
        public static IEnumerable<List<T>> InSetsOf<T>(this IEnumerable<T> source, int max = 100)
        {
            var toReturn = new List<T>(max);
            foreach (var item in source)
            {
                toReturn.Add(item);
                if (toReturn.Count == max)
                {
                    yield return toReturn;
                    toReturn = new List<T>(max);
                }
            }
            if (toReturn.Any())
            {
                yield return toReturn;
            }
        }

        /// <summary>
        ///   Merges three sequences by using the specified predicate function.
        /// </summary>
        /// <typeparam name = "TFirst">The type of the elements of the first input sequence.</typeparam>
        /// <typeparam name = "TSecond">The type of the elements of the second input sequence.</typeparam>
        /// <typeparam name = "TThird">The type of the elements of the third input sequence.</typeparam>
        /// <typeparam name = "TResult">The type of the elements of the result sequence.</typeparam>
        /// <param name = "first">The first sequence to merge.</param>
        /// <param name = "second">The second sequence to merge.</param>
        /// <param name = "third">The third sequence to merge.</param>
        /// <param name = "resultSelector">A function that specifies how to merge the elements from the three sequences.</param>
        /// <returns>An <see cref = "IEnumerable{T}" /> that contains merged elements of three input sequences.</returns>
        public static IEnumerable<TResult> Zip<TFirst, TSecond, TThird, TResult>(
            this IEnumerable<TFirst> first,
            IEnumerable<TSecond> second,
            IEnumerable<TThird> third,
            Func<TFirst, TSecond, TThird, TResult> resultSelector)
        {
            CodeGuard.ArgumentNotNull((object)first, "first");
            CodeGuard.ArgumentNotNull((object)second, "second");
            CodeGuard.ArgumentNotNull((object)third, "third");
            CodeGuard.ArgumentNotNull(resultSelector, "resultSelector");

            using (IEnumerator<TFirst> iterator1 = first.GetEnumerator())
            {
                using (IEnumerator<TSecond> iterator2 = second.GetEnumerator())
                {
                    using (IEnumerator<TThird> iterator3 = third.GetEnumerator())
                    {
                        while (iterator1.MoveNext() && iterator2.MoveNext() && iterator3.MoveNext())
                        {
                            yield return resultSelector(iterator1.Current, iterator2.Current, iterator3.Current);
                        }
                    }
                }
            }
        }

        public static object CreateEmptyListOfType(Type itemType)
        {
            var listType = typeof(List<>);
            var constructedListType = listType.MakeGenericType(itemType);
            var instance = Activator.CreateInstance(constructedListType);
            return instance;
        }

        /// <summary>
        /// Führt die angegebene Aktion für jedes Element der IEnumerable&lt;T&gt; aus. Unterteilt die 
        /// IEnumerable&lt;T&gt; in Sets aus maximal max Elementen.
        /// </summary>
        /// <typeparam name="T">Typ der IEnumerable</typeparam>
        /// <param name="source"></param>
        /// <param name="action">Der Action&lt;IEnumerable&lt;T&gt;&gt;(IEnumerable&lt;T&gt;)-Delegat, 
        /// der für jedes Element jedes Sets von IEnumerable&lt;T&gt; ausgeführt werden soll.</param>
        /// <param name="max">Setzt die maximale Anzahl von Elementen pro Set.</param>
        public static void ForEachInSetsOf<T>(this IEnumerable<T> source, Action<IEnumerable<T>> action,
            int max = 100)
        {
            InSetsOf(source, max).ForEach(action);
        }
        
        #endregion
    }
}
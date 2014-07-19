using System;
using System.Collections.Generic;
using System.Linq;

namespace Utils.Extensions.Collections
{
    public static class Extensions
    {
        #region Concurrent-style
        public static TValue AddOrUpdate<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key, TValue newValue, Func<TKey, TValue, TValue> updateValue)
        {
            TValue val;
            if (!dict.TryGetValue(key, out val))
                dict.Add(key, newValue);
            else
                dict[key] = updateValue(key, dict[key]);

            return dict[key];
        }
        public static TValue AddOrUpdate<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key, Func<TKey, TValue> newValue, Func<TKey, TValue, TValue> updateValue)
        {
            TValue val;
            if (!dict.TryGetValue(key, out val))
                dict.Add(key, newValue(key));
            else
                dict[key] = updateValue(key, dict[key]);

            return dict[key];
        }

        public static bool TryUpdate<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key, Func<TKey, TValue, TValue> updateValue)
        {
            if (dict.ContainsKey(key))
            {
                dict[key] = updateValue(key, dict[key]);
                return true;
            }

            return false;
        }

        public static bool TryUpdate<TKey, TValue>(this IDictionary<TKey, TValue> dict, TKey key, Func<TKey, TValue, TValue> updateValue, out TValue newVal)
        {
            if (dict.ContainsKey(key))
            {
                newVal = updateValue(key, dict[key]);
                dict[key] = newVal;
                return true;
            }

            newVal = default(TValue);
            return false;
        }
        #endregion

        #region WithEvery<T>
        //copypasta from http://blog.functionalfun.net/2008/07/reporting-progress-during-linq-queries.html
        public static IEnumerable<T> WithEvery<T>(this IEnumerable<T> sequence, Action<int, int> reportProgress)
        {
            if (sequence == null) { throw new ArgumentNullException("sequence"); }

            ICollection<T> collection = sequence as ICollection<T>;
            if (collection == null)
                collection = new List<T>(sequence);

            int total = collection.Count;
            return collection.WithEvery(total, reportProgress);
        }

        public static IEnumerable<T> WithEvery<T>(this IEnumerable<T> sequence, int itemCount, Action<int, int> reportProgress)
        {
            if (sequence == null) { throw new ArgumentNullException("sequence"); }

            int completed = 0;
            foreach (var item in sequence)
            {
                yield return item;

                completed++;
                reportProgress(completed, itemCount);
            }
        }
        #endregion

        public static IEnumerable<T> Combine<T>(this IEnumerable<T> col1, IEnumerable<T> col2)
        {
            foreach (T item in col1)
                yield return item;

            foreach (T item in col2)
                yield return item;
        }

        public static List<T> GetRandomElements<T>(this IEnumerable<T> collection, int elements)
        {
            var retList = new List<T>(elements);
            var list = collection.ToList();

            if (list.Count < elements)
                throw new ArgumentOutOfRangeException("Collection doesn't have " + elements + " elements to return.");

            int newCount = elements;

            var rand = new Random();
            for (int i = 0; i < list.Count; i++)
            {
                double chance = (double)newCount / (list.Count - i);
                if (rand.NextDouble() <= chance)
                {
                    retList.Add(list[i]);
                    newCount--;

                    if (newCount == 0)
                        break;
                }
            }

            return retList;
        }

        public static Dictionary<T, bool> AddRange<T>(this HashSet<T> set, IEnumerable<T> toAdd)
        {
            var dict = new Dictionary<T, bool>();
            foreach (var entry in toAdd)
                dict.Add(entry, set.Add(entry));

            return dict;
        }

        public static IDictionary<string, EV> EnumToDictionary<E, EV>() where E : struct
        {
            return Enum.GetValues(typeof(E)).Cast<EV>().ToDictionary(currentItem => Enum.GetName(typeof(E), currentItem));
        }
    }
}
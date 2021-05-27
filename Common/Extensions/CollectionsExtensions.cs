using System;
using System.Collections.Generic;
using System.Linq;

namespace Common.Extensions
{
    public static class CollectionsExtensions
    {
        /// <summary>
        /// Применяется для удаления "выбранного" элемента списка.
        /// Возвращает элемент, который необходимо "выбрать" после удаления текущего.
        /// </summary>
        public static T RemoveSelected<T>(this IList<T> list, T selectedItem)
        {
            var selectedIndex = list.IndexOf(selectedItem);

            list.Remove(selectedItem);

            if (selectedIndex >= list.Count)
            {
                selectedIndex = list.Count - 1;
            }
            if (selectedIndex > -1)
            {
                return list[selectedIndex];
            }

            return default(T);
        }

        /// <summary>
        /// Группирует элементы последовательности в соответствии с заданной функцией селектора ключа.
        /// </summary>
        public static IEnumerable<IGrouping<TKey, TSource>> GroupBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, int, TKey> keySelector)
        {
            return source
               .Select((item, number) => new { item, number })
               .GroupBy(a => keySelector(a.item, a.number), a => a.item);
        }

        /// <summary>
        /// Группирует элементы последовательности в соответствии с заданной функцией селектора ключа
        /// и создает результирующее значение для каждой группы.
        /// </summary>
        public static IEnumerable<TResult> GroupBy<TSource, TKey, TResult>(this IEnumerable<TSource> source, Func<TSource, int, TKey> keySelector, Func<IEnumerable<TSource>, TResult> resultSelector)
        {
            return source
                .GroupBy(keySelector)
                .Select((group) => resultSelector(group));
        }

        /// <summary>
        /// Группирует элементы последовательности по указанное количество штук
        /// и создает результирующее значение для каждой группы.
        /// </summary>
        public static IEnumerable<TResult> GroupBy<TSource, TResult>(this IEnumerable<TSource> source, int count, Func<IEnumerable<TSource>, TResult> resultSelector)
        {
            return source.GroupBy((item, number) => number / count, resultSelector);
        }
    }
}

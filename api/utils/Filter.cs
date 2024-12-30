using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Stock;
using api.Models;

namespace api.utils
{
    public static class Filter
    {

        public static List<T> Limit<T>(this IEnumerable<T> items, int itemNumber)
        {
            return items.Take(itemNumber).ToList();
        }

        public static IEnumerable<T> ApplyLimit<T>(this IEnumerable<T> items, int itemNumber)
        {
            return items.Take(itemNumber);
        }

        public static int ApplyCount<T>(this IEnumerable<T> items)
        {
            return items.Count();
        }

        public static IEnumerable<T> ApplyOrderBy<T, TKey>(this IEnumerable<T> items, Func<T, TKey> keySelector)
        {
            return items.OrderBy(keySelector);
        }

    }
}
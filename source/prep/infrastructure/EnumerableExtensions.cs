using System;
using System.Collections.Generic;
using prep.infrastructure.filtering;
using prep.infrastructure.ordering;
using prep.infrastructure.sorting;

namespace prep.infrastructure
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> one_at_a_time<T>(this IEnumerable<T> items)
        {
            foreach (var item in items) yield return item;
        }

        public static IEnumerable<T> all_items_matching<T>(this IEnumerable<T> items, IMatchAn<T> criteria)
        {
            return items.all_items_matching(criteria.matches);
        }

        public static IEnumerable<T> all_items_matching<T>(this IEnumerable<T> items, Criteria<T> criteria)
        {
            foreach (var item in items)
            {
                if (criteria(item))
                    yield return item;
            }
        }

        public static IterationExtensionPoint<ItemToMatch, PropertyType> where<ItemToMatch, PropertyType>(this IEnumerable<ItemToMatch> items
            , Func<ItemToMatch, PropertyType> accessor)
        {
            return new IterationExtensionPoint<ItemToMatch, PropertyType>(items,Where<ItemToMatch>.has_a(accessor));
        }

        public static SortingExtensionPoint<ItemToSort,PropertyType> order<ItemToSort, PropertyType>( this IEnumerable<ItemToSort> items,
            Func<ItemToSort, PropertyType> accessor) where PropertyType : IComparable{

            return new SortingExtensionPoint<ItemToSort, PropertyType>(items, accessor);
        }
    }
}
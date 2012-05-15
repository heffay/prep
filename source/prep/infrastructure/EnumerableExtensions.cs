﻿using System;
using System.Collections.Generic;
using prep.infrastructure.filtering;

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

        public static IProvideAccessToCreatingMatchers<ItemToMatch, PropertyType> where<ItemToMatch, PropertyType>(
            this IEnumerable<ItemToMatch> items, Func<ItemToMatch, PropertyType> accessor){

            return Where<ItemToMatch>.has_a(accessor);
            
        }
    }
}
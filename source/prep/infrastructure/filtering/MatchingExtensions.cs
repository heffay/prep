﻿using System;

namespace prep.infrastructure.filtering
{
    public static class MatchingExtensions
    {
        public static IMatchAn<ItemToMatch> equal_to<ItemToMatch, PropertyType>(
            this IProvideAccessToCreatingMatchers<ItemToMatch, PropertyType> extension_point, PropertyType value_to_equal)
        {
            return equal_to_any(extension_point, value_to_equal);
        }

        public static IMatchAn<ItemToMatch> equal_to_any<ItemToMatch, PropertyType>(
            this IProvideAccessToCreatingMatchers<ItemToMatch, PropertyType> extension_point, params PropertyType[] values)
        {
            return create_using(extension_point, new EqualToAny<PropertyType>(values));
        }

        public static IMatchAn<ItemToMatch> create_using<ItemToMatch, PropertyType>(
            this IProvideAccessToCreatingMatchers<ItemToMatch, PropertyType> extension_point, IMatchAn<PropertyType> real_criteria)
        {
            return extension_point.create_using(real_criteria);
        }

        public static IMatchAn<ItemToMatch> greater_than<ItemToMatch, PropertyType>(
            this IProvideAccessToCreatingMatchers<ItemToMatch, PropertyType> extension_point, PropertyType value)
            where PropertyType : IComparable<PropertyType>
        {
            return create_using(extension_point,
                                new FallsInRange<PropertyType>(new Range<PropertyType>().GreaterThan(value).Range));
        }

        public static IMatchAn<ItemToMatch> between<ItemToMatch, PropertyType>(
            this IProvideAccessToCreatingMatchers<ItemToMatch, PropertyType> extension_point, PropertyType start, PropertyType end)
            where PropertyType : IComparable<PropertyType>
        {
            return
                create_using(extension_point,
                             new FallsInRange<PropertyType>(
                                 new Range<PropertyType>().GreaterThan(start).Inclusive().And.LessThan(end).Inclusive().
                                     Range));
        }
    }
}

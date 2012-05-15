using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using prep.infrastructure.filtering;

namespace prep.infrastructure {
    public static class EnumerableMatchingExtensions {

        public static IEnumerable<ItemToMatch> equal_to<ItemToMatch, PropertyType>(
            this IProvideAccessToCreatingMatchers<ItemToMatch, PropertyType> extension_point, PropertyType value_to_equal ) {
            
            yield return equal_to_any(extension_point, value_to_equal);
        }

        public static IMatchAn<ItemToMatch> equal_to_any<ItemToMatch, PropertyType>(
            this IProvideAccessToCreatingMatchers<ItemToMatch, PropertyType> extension_point, params PropertyType[] values ) {
            return create_using(extension_point, new EqualToAny<PropertyType>(values));
        }

        public static IMatchAn<ItemToMatch> create_using<ItemToMatch, PropertyType>(
            this IProvideAccessToCreatingMatchers<ItemToMatch, PropertyType> extension_point, IMatchAn<PropertyType> real_criteria ) {
            return extension_point.create_using(real_criteria);
        }

        public static IMatchAn<ItemToMatch> greater_than<ItemToMatch, PropertyType>(
            this IProvideAccessToCreatingMatchers<ItemToMatch, PropertyType> extension_point, PropertyType value )
            where PropertyType : IComparable<PropertyType> {
            return create_using(extension_point,
                                new FallsInRange<PropertyType>(new Range<PropertyType>().GreaterThan(value).Range));
        }

        public static IMatchAn<ItemToMatch> between<ItemToMatch, PropertyType>(
            this IProvideAccessToCreatingMatchers<ItemToMatch, PropertyType> extension_point, PropertyType start, PropertyType end )
            where PropertyType : IComparable<PropertyType> {
            return
                create_using(extension_point,
                             new FallsInRange<PropertyType>(
                                 new Range<PropertyType>().GreaterThan(start).Inclusive().And.LessThan(end).Inclusive().
                                     Range));
        }
    }
}

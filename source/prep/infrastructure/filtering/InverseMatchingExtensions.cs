using System;

namespace prep.infrastructure.filtering
{
    public static class InverseMatchingExtensions
    {
        public static IMatchAn<ItemToMatch> equal_to<ItemToMatch, PropertyType>(
            this InverseMatchingExtensionPoint<ItemToMatch, PropertyType> extension_point, PropertyType value_to_equal)
        {
            return extension_point.equal_to_any(value_to_equal).not();            
        }

        public static IMatchAn<ItemToMatch> equal_to_any<ItemToMatch, PropertyType>(
            this InverseMatchingExtensionPoint<ItemToMatch, PropertyType> extension_point, params PropertyType[] values)
        {
            return extension_point.create_using(new EqualToAny<PropertyType>(values)).not();
        }

        public static IMatchAn<ItemToMatch> create_using<ItemToMatch, PropertyType>(
            this InverseMatchingExtensionPoint<ItemToMatch, PropertyType> extension_point, IMatchAn<PropertyType> real_criteria)
        {
            return new PropertyMatcher<ItemToMatch, PropertyType>(extension_point.accessor, real_criteria);
        }

        public static IMatchAn<ItemToMatch> greater_than<ItemToMatch, PropertyType>(
            this InverseMatchingExtensionPoint<ItemToMatch, PropertyType> extension_point, PropertyType value) where PropertyType : IComparable<PropertyType>
        {
            return create_using(extension_point,
                                new FallsInRange<PropertyType>(new Range<PropertyType>().GreaterThan(value).Range)).not();
        }

        public static IMatchAn<ItemToMatch> between<ItemToMatch, PropertyType>(
            this InverseMatchingExtensionPoint<ItemToMatch, PropertyType> extension_point, PropertyType start, PropertyType end) where PropertyType : IComparable<PropertyType>
        {
            return
                create_using(extension_point,
                             new FallsInRange<PropertyType>(
                                 new Range<PropertyType>().GreaterThan(start).Inclusive().And.LessThan(end).Inclusive().Range)).not();
        }
    }
}
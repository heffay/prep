using System;
using prep.infrastructure.ranges;

namespace prep.infrastructure.filtering
{
    public class ComparableCriteriaFactory<ItemToMatch, PropertyType> : ICreateMatchers<ItemToMatch, PropertyType>
        where PropertyType : IComparable<PropertyType>
    {
        ICreateMatchers<ItemToMatch, PropertyType> original_criteria_factory;

        public ComparableCriteriaFactory(ICreateMatchers<ItemToMatch, PropertyType> original_criteria_factory)
        {
            this.original_criteria_factory = original_criteria_factory;
        }

        public IMatchAn<ItemToMatch> greater_than(PropertyType value)
        {
            return create_using(new FallsInRange<PropertyType>(new Range<PropertyType>().GreaterThan(value).Range));
        }

        public IMatchAn<ItemToMatch> between(PropertyType start, PropertyType end)
        {
            return create_using(new FallsInRange<PropertyType>(new Range<PropertyType>().GreaterThan(start).Inclusive().And.LessThan(end).Inclusive().Range));
        }

        public IMatchAn<ItemToMatch> equal_to(PropertyType value_to_equal)
        {
            return original_criteria_factory.equal_to(value_to_equal);
        }

        public IMatchAn<ItemToMatch> equal_to_any(params PropertyType[] values)
        {
            return original_criteria_factory.equal_to_any(values);
        }

        public IMatchAn<ItemToMatch> create_using(IMatchAn<PropertyType> real_criteria)
        {
            return original_criteria_factory.create_using(real_criteria);
        }

        public IMatchAn<ItemToMatch> not_equal_to(PropertyType value)
        {
            return original_criteria_factory.not_equal_to(value);
        }
    }
}
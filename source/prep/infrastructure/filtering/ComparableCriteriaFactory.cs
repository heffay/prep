using System;

namespace prep.infrastructure.filtering
{
    public class ComparableCriteriaFactory<ItemToMatch, PropertyType> : ICreateMatchers<ItemToMatch, PropertyType>
        where PropertyType : IComparable<PropertyType>
    {
        Func<ItemToMatch, PropertyType> accessor;
        ICreateMatchers<ItemToMatch, PropertyType> original_criteria_factory;

        public ComparableCriteriaFactory(Func<ItemToMatch, PropertyType> accessor,
                                         ICreateMatchers<ItemToMatch, PropertyType> original_criteria_factory)
        {
            this.accessor = accessor;
            this.original_criteria_factory = original_criteria_factory;
        }

        public IMatchAn<ItemToMatch> greater_than(PropertyType value)
        {
            return original_criteria_factory.create_using(x => accessor(x).CompareTo(value) > 0);
        }

        public IMatchAn<ItemToMatch> between(PropertyType start, PropertyType end)
        {
            return
                original_criteria_factory.create_using(
                    x => accessor(x).CompareTo(start) >= 0 && accessor(x).CompareTo(end) <= 0);
        }

        public IMatchAn<ItemToMatch> equal_to(PropertyType value_to_equal)
        {
            return original_criteria_factory.equal_to(value_to_equal);
        }

        public IMatchAn<ItemToMatch> equal_to_any(params PropertyType[] values)
        {
            return original_criteria_factory.equal_to_any(values);
        }

        public IMatchAn<ItemToMatch> create_using(Criteria<ItemToMatch> condition)
        {
            return original_criteria_factory.create_using(condition);
        }

        public IMatchAn<ItemToMatch> not_equal_to(PropertyType value)
        {
            return original_criteria_factory.not_equal_to(value);
        }
    }
}
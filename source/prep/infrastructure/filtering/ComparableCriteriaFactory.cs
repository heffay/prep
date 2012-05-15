using System;

namespace prep.infrastructure.filtering
{
    public class ComparableCriteriaFactory<ItemToMatch, PropertyType> where PropertyType : IComparable<PropertyType>
    {
        Func<ItemToMatch, PropertyType> accessor;

        public ComparableCriteriaFactory(Func<ItemToMatch, PropertyType> accessor)
        {
            this.accessor = accessor;
        }

        public IMatchAn<ItemToMatch> greater_than(PropertyType value)
        {
            return new AnonymousMatch<ItemToMatch>(x => accessor(x).CompareTo(value) > 0);
        }

        public IMatchAn<ItemToMatch> between(PropertyType start, PropertyType end)
        {
            return
                new AnonymousMatch<ItemToMatch>(
                    x => accessor(x).CompareTo(start) >= 0 && accessor(x).CompareTo(end) <= 0);
        }
    }
}
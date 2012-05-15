using System;

namespace prep.infrastructure.filtering
{
    public class PropertyMatcher<ItemToMatch,PropertyType> : IMatchAn<ItemToMatch>
    {
        Func<ItemToMatch, PropertyType> accessor;
        IMatchAn<PropertyType> real_criteria;

        public PropertyMatcher(Func<ItemToMatch, PropertyType> accessor, IMatchAn<PropertyType> real_criteria)
        {
            this.accessor = accessor;
            this.real_criteria = real_criteria;
        }

        public bool matches(ItemToMatch item)
        {
            var value_to_check = accessor(item);
            return real_criteria.matches(value_to_check);
        }
    }
}
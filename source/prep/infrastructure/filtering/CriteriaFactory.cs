using System;
using System.Collections.Generic;

namespace prep.infrastructure.filtering
{
    public class CriteriaFactory<ItemToMatch, PropertyType> : IEqualityCriteriaFactory<ItemToMatch, PropertyType>, ICreateMatchers<ItemToMatch, PropertyType>
    {
        Func<ItemToMatch, PropertyType> accessor;

        public CriteriaFactory(Func<ItemToMatch, PropertyType> accessor)
        {
            this.accessor = accessor;
        }

        public IMatchAn<ItemToMatch> equal_to(PropertyType value_to_equal)
        {
            return equal_to_any(value_to_equal);
        }

        public IMatchAn<ItemToMatch> equal_to_any(params PropertyType[] values)
        {
            return create_using(x => new List<PropertyType>(values).Contains(accessor(x)));
        }

        public IMatchAn<ItemToMatch> create_using(Criteria<ItemToMatch> condition)
        {
            return new AnonymousMatch<ItemToMatch>(condition);
        }

        public IMatchAn<ItemToMatch> not_equal_to(PropertyType value)
        {
            return equal_to(value).not();
        }
    }
}
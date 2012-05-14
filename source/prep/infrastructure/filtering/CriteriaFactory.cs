using System;
using System.Linq;

namespace prep.infrastructure.filtering
{
    public class CriteriaFactory<ItemToMatch, PropertyType>
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
            return new AnonymousMatch<ItemToMatch>(x => values.Contains(accessor(x)));
        }
    }
}
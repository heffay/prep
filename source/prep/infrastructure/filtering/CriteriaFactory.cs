using System;

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
            return new AnonymousMatch<ItemToMatch>(x => accessor(x).Equals(value_to_equal));
        }

        public IMatchAn<ItemToMatch> equal_to_any(params PropertyType[] values)
        {
            throw new NotImplementedException();
        }
    }
}
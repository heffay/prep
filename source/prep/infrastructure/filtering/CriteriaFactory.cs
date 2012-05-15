using System;

namespace prep.infrastructure.filtering
{
    public class CriteriaFactory<ItemToMatch, PropertyType> : IEqualityCriteriaFactory<ItemToMatch, PropertyType>,
                                                              ICreateMatchers<ItemToMatch, PropertyType>
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
            return create_using(new EqualToAny<PropertyType>(values));
        }

        public IMatchAn<ItemToMatch> create_using(IMatchAn<PropertyType> real_criteria)
        {
            return new PropertyMatcher<ItemToMatch, PropertyType>(accessor, real_criteria);
        }


        public IMatchAn<ItemToMatch> not_equal_to(PropertyType value)
        {
            return equal_to(value).not();
        }
    }
}
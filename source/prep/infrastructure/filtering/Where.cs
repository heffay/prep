using System;

namespace prep.infrastructure.filtering
{
    public class EqualTo<ItemToMatch, PropertyType>
    {
        private readonly Func<ItemToMatch, PropertyType> _accessor;

        public EqualTo(Func<ItemToMatch, PropertyType> accessor)
        {
            _accessor = accessor;
        }

        public IMatchAn<ItemToMatch> equal_to(PropertyType property)
        {
            return new EqualToMatcher<ItemToMatch, PropertyType>(_accessor, property);
        }
    }

    public class EqualToMatcher<ItemToMatch, PropertyType> : IMatchAn<ItemToMatch>
    {
        private readonly Func<ItemToMatch, PropertyType> _accessor;
        private readonly PropertyType _source;

        public EqualToMatcher(Func<ItemToMatch, PropertyType> accessor, PropertyType source)
        {
            _accessor = accessor;
            _source = source;
        }

        public bool matches(ItemToMatch item)
        {
            return _accessor(item).Equals(_source);
        }
    }

    public class Where<ItemToMatch>
    {
        public static EqualTo<ItemToMatch, PropertyType> has_a<PropertyType>(Func<ItemToMatch, PropertyType> accessor)
        {
            return new EqualTo<ItemToMatch, PropertyType>(accessor);
        }        
    }
}
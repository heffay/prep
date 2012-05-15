using System;

namespace prep.infrastructure.filtering
{
    public class Where<ItemToMatch>
    {
        public static MatchingExtensionPoint<ItemToMatch,PropertyType> has_a<PropertyType>(Func<ItemToMatch, PropertyType> accessor)
        {
            return new MatchingExtensionPoint<ItemToMatch,PropertyType>(accessor);
        }
    }
}
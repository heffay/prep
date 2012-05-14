using System;

namespace prep.infrastructure.filtering
{
    public class Where<ItemToMatch>
    {
        public static Func<ItemToMatch,PropertyType> has_a<PropertyType>(Func<ItemToMatch, PropertyType> accessor)
        {
            return accessor;
        }
    }
}
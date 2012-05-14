using System;

namespace prep.infrastructure.filtering
{
    public class Where<ItemToMatch>
    {
        public static  has_a<PropertyType>(Func<ItemToMatch, PropertyType> accessor)
        {

        }
    }
}
using System;

namespace prep.infrastructure.filtering
{
    public class InverseMatchingExtensionPoint<ItemToMatch, PropertyType> : MatchingExtensionPoint<ItemToMatch,PropertyType>
    {        
        public InverseMatchingExtensionPoint(Func<ItemToMatch, PropertyType> accessor) : base(accessor)
        {
        }
    }
}
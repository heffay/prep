using System;

namespace prep.infrastructure.filtering
{
    public class MatchingExtensionPoint<ItemToMatch,PropertyType>
    {
        public Func<ItemToMatch, PropertyType> accessor { get; set; }

        public MatchingExtensionPoint(Func<ItemToMatch, PropertyType> accessor)
        {
            this.accessor = accessor;
        }
    }
}
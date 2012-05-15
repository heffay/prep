using System;
using System.Collections.Generic;

namespace prep.infrastructure.filtering
{
    public class MovieIterationExtensionPoint<ItemToMatch, PropertyType>
    {
        private readonly IEnumerable<ItemToMatch> collection;
        private readonly Func<ItemToMatch, PropertyType> accessor;

        public MovieIterationExtensionPoint(IEnumerable<ItemToMatch> collection, Func<ItemToMatch, PropertyType> accessor)
        {
            this.collection = collection;
            this.accessor = accessor;
        }

        public IEnumerable<ItemToMatch> equal_to_any(params PropertyType[] values)
        {
            foreach(var item in collection)
                if(Where<ItemToMatch>.has_a(accessor).equal_to_any(values).matches(item))
                    yield return item;
        }
    }
}
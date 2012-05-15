using System;
using System.Collections.Generic;

namespace prep.infrastructure.filtering
{
    public static class MovieIterationExtension
    {
        public static MovieIterationExtensionPoint<ItemToMatch, PropertyType> where<ItemToMatch, PropertyType>(this IEnumerable<ItemToMatch> collection, Func<ItemToMatch, PropertyType> accessor)
        {
            return new MovieIterationExtensionPoint<ItemToMatch, PropertyType>(collection,accessor);
        }
    }
}
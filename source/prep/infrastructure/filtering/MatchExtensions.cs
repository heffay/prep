using System;

namespace prep.infrastructure.filtering
{
    public static class MatchExtensions
    {
        public static IMatchAn<ItemToMatch> equal_to<ItemToMatch,PropertyType>(this Func<ItemToMatch, PropertyType> accessor, PropertyType value)
        {
            return new AnonymousMatch<ItemToMatch>(x => accessor(x).Equals(value));
        }

        public static IMatchAn<Item> or<Item>(this IMatchAn<Item> left, IMatchAn<Item> right)
        {
            return new OrMatch<Item>(left, right);
        }
    }
}
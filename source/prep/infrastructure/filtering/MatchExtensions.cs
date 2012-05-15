namespace prep.infrastructure.filtering
{
    public static class MatchExtensions
    {
        public static IMatchAn<Item> or<Item>(this IMatchAn<Item> left, IMatchAn<Item> right)
        {
            return new OrMatch<Item>(left, right);
        }

        public static IMatchAn<Item> not<Item>(this IMatchAn<Item> to_negate)
        {
            return new NegatingMatch<Item>(to_negate);
        }
    }

      
}
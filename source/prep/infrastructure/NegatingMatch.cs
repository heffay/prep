namespace prep.infrastructure
{
    public class NegatingMatch<Item> : IMatchAn<Item>
    {
        IMatchAn<Item> to_negate;

        public NegatingMatch(IMatchAn<Item> to_negate)
        {
            this.to_negate = to_negate;
        }

        public bool matches(Item item)
        {
            return ! to_negate.matches(item);
        }
    }
}
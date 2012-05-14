namespace prep.infrastructure.filtering
{
    public class NeverMatches<Item> : IMatchAn<Item>
    {
        public bool matches(Item item)
        {
            return false;
        }
    }
}
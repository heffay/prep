namespace prep.infrastructure.filtering
{
    public class AnonymousMatch<Item> : IMatchAn<Item>
    {
        Criteria<Item> condition;

        public AnonymousMatch(Criteria<Item> condition)
        {
            this.condition = condition;
        }

        public bool matches(Item item)
        {
            return condition(item);
        }
    }
}
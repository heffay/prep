using System;

namespace prep.infrastructure
{
    public class NotMatch<Item> : IMatchAn<Item>
    {
        private readonly IMatchAn<Item> sourceMatch;

        public NotMatch(IMatchAn<Item> sourceMatch)
        {
            this.sourceMatch = sourceMatch;
        }

        public bool matches(Item item)
        {
            return !sourceMatch.matches(item);
        }
    }
}
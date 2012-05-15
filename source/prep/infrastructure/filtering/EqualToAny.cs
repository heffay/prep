using System.Collections.Generic;

namespace prep.infrastructure.filtering
{
    public class EqualToAny<T> : IMatchAn<T>
    {
        IList<T> values;

        public EqualToAny(params T[] values)
        {
            this.values = new List<T>(values);
        }

        public bool matches(T item)
        {
            return values.Contains(item);
        }
    }
}
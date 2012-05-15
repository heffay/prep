using System;
using prep.infrastructure.ranges;

namespace prep.infrastructure.filtering
{
    public class FallsInRange<T> : IMatchAn<T> where T : IComparable<T>
    {
        IContainValues<T> range;

        public FallsInRange(IContainValues<T> range)
        {
            this.range = range;
        }

        public bool matches(T item)
        {
            return range.contains(item);
        }
    }
}
using System;

namespace prep.infrastructure.ranges
{
    public class ExclusiveRangeWithNoUpperBound<T> :IContainValues<T> where T : IComparable<T>
    {
        T start;

        public ExclusiveRangeWithNoUpperBound(T start)
        {
            this.start = start;
        }

        public bool contains(T item)
        {
            return item.CompareTo(start) > 0;
        }
    }
}
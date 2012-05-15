using System;
using prep.infrastructure.ranges;

namespace prep.infrastructure
{
    public class RangeBoundary<T> : IContainValues<T> where T : IComparable<T>
    {
        private T boundary;
        private readonly Range<T> range;
        private bool isInclusive;

        public RangeBoundary(T boundary, Range<T> range)
        {
            this.boundary = boundary;
            this.range = range;
        }

        public T Boundary
        {
            get { return boundary; }
        }

        public bool IsInclusive
        {
            get { return isInclusive; }
        }

        public RangeBoundary<T> Inclusive()
        {
            isInclusive = true;
            return this;
        }

        public Range<T> Range
        {
            get { return range; }
        }

        public RangeBoundary<T> Exclusive()
        {
            isInclusive = false;
            return this;
        }

        public Range<T> And { get { return range; } }

        public bool contains(T value)
        {
            return isInclusive && boundary.CompareTo(value) == 0;
        }
    }
}
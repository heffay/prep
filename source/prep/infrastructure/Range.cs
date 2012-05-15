using System;
using prep.infrastructure.ranges;

namespace prep.infrastructure
{
    public class Range<T> : IContainValues<T>  where T : IComparable<T>
    {
        private RangeBoundary<T> lowerBound;
        private RangeBoundary<T> upperBound;
        private bool isLowerInclusive;
        private bool isUpperInclusive;
        public RangeBoundary<T> GreaterThan(T value)
        {
            lowerBound = new RangeBoundary<T>(value, this);
            return lowerBound;
        }
        public RangeBoundary<T> LessThan(T value)
        {
            upperBound = new RangeBoundary<T>(value, this);
            return upperBound;
        }


        public Range()
        {
        }

        public bool contains(T value)
        {
            if(lowerBound == null)
            {
                if(upperBound == null)
                {
                    return false;
                }

                return upperBound.contains(value) || value.CompareTo(upperBound.Boundary) < 0;
            }
            else
            {
                var lowerResult = lowerBound.contains(value) || value.CompareTo(lowerBound.Boundary) > 0;
                if(upperBound != null)
                {
                    return upperBound.contains(value) ||
                        (lowerResult && value.CompareTo(upperBound.Boundary) < 0 && value.CompareTo(lowerBound.Boundary) > 0);
                }
                else
                {
                    return lowerResult;
                }

            }
        }

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

            public Range<T> And{get { return range; }}

            public bool contains(T value)
            {
                return isInclusive && boundary.CompareTo(value) == 0;
            }
        }
    }

    //sample syntax
    //new Range().GreaterThan(3).Inclusive().And.LessThan(5).Inclusive()


}
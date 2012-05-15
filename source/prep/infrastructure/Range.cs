using System;
using prep.infrastructure.ranges;

namespace prep.infrastructure
{
    public class Range<T> : IContainValues<T>  where T : IComparable<T>
    {
        private RangeBoundary<T> lowerBound;
        private RangeBoundary<T> upperBound;
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
                        (lowerResult && value.CompareTo(upperBound.Boundary) < 0);
                }
                else
                {
                    return lowerResult;
                }

            }
        }

 
    }


    //sample syntax
    //new Range.GreaterThan(3).Inclusive().And.LessThan(5).Inclusive()


}
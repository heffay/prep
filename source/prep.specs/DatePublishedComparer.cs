using System;
using System.Collections.Generic;
using prep.collections;

namespace prep.specs
{
    public class DatePublishedComparer : IComparer<Movie>
    {
        public int Compare(Movie x, Movie y)
        {
            // > 0 == x > y
            // < 0 == x < y
            // = 0 == x = y
            throw new NotImplementedException();
        }
    }
}
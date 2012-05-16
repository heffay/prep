using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using prep.infrastructure.ordering;

namespace prep.infrastructure.sorting {
    public static class By<PropertyType> where PropertyType : IComparable{
        public readonly static ISortStrategy<PropertyType> ASC = new ASCSortStrategy<PropertyType>();
        public readonly static ISortStrategy<PropertyType> DESC = new DESCSortStrategy<PropertyType>();
    }
}

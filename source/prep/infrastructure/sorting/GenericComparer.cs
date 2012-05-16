using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace prep.infrastructure.ordering {
    public interface ISortStrategy<PropertyType>{
        int Compare( PropertyType a, PropertyType b );
    }

    public class ASCSortStrategy<PropertyType> : ISortStrategy<PropertyType> where PropertyType : IComparable {
        public int Compare( PropertyType a, PropertyType b ) {
            return a.CompareTo(b);
        }
    }
    public class DESCSortStrategy<PropertyType> : ISortStrategy<PropertyType> where PropertyType : IComparable {
        public int Compare( PropertyType a, PropertyType b ) {
            return b.CompareTo(a);
        }
    }

    public class GenericComparer<ItemToSort, PropertyType> : IComparer<ItemToSort> where PropertyType : IComparable{
        private Func<ItemToSort, PropertyType> accessor;
        private ISortStrategy<PropertyType> sort_strategy;

        public int Compare(ItemToSort x, ItemToSort y){
            return sort_strategy.Compare(accessor(x), accessor(y));
        }

        public GenericComparer( Func<ItemToSort, PropertyType> accessor, ISortStrategy<PropertyType> sortStrategy ) {
            this.accessor = accessor;
            this.sort_strategy = sortStrategy;
        }
    }
}

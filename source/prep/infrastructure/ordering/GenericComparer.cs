using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace prep.infrastructure.ordering {
    public class GenericComparer<ItemToSort, PropertyType> : IComparer<ItemToSort> where PropertyType : IComparable{
        private Func<ItemToSort, PropertyType> accessor;

        public int Compare(ItemToSort x, ItemToSort y){
            return accessor(y).CompareTo(accessor(x));
        }

        public GenericComparer(Func<ItemToSort, PropertyType> accessor){
            this.accessor = accessor;
        }
    }
}

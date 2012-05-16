using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using prep.infrastructure.ordering;

namespace prep.infrastructure.sorting {
    public class SortingExtensionPoint<ItemToSort,PropertyType> :IEnumerable<ItemToSort> where PropertyType : IComparable{
        private List<ItemToSort> items;
        private Func<ItemToSort, PropertyType> accessor;
        private IComparer<ItemToSort> comparer;

        public SortingExtensionPoint(IEnumerable<ItemToSort> items, Func<ItemToSort, PropertyType> accessor){
            this.items = items.ToList();
            this.accessor = accessor;
            this.comparer = new GenericComparer<ItemToSort, PropertyType>(accessor, new ASCSortStrategy<PropertyType>());
        }

        public SortingExtensionPoint( IEnumerable<ItemToSort> items, Func<ItemToSort, PropertyType> accessor, IComparer<ItemToSort> comparer ) {
            this.items = items.ToList();
            this.accessor = accessor;
            this.comparer = comparer;
        }

        public IEnumerator<ItemToSort> GetEnumerator(){
            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator(){
            return items.GetEnumerator();
        }

        public IEnumerable<ItemToSort> ASC {
            get{
                items.Sort(
                    comparer);
                return items;
            }
        }

        public IEnumerable<ItemToSort> DESC {
            get{
                items.Sort(
                    new GenericComparer<ItemToSort, PropertyType>(accessor, new DESCSortStrategy<PropertyType>()));
                return items;
            }
        }
    }
}

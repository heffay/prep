using System.Collections;
using System.Collections.Generic;

namespace prep.collections
{
    public class ReadOnlyList<T> : IEnumerable<T>
    {
        readonly IEnumerable<T> items;

        public ReadOnlyList(IEnumerable<T> items)
        {
            this.items = items;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
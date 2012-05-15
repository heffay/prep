using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace prep.infrastructure.filtering
{
    public class AnonymousMatchFactory<Item>
    {
        public AnonymousMatch<Item> GetInstance(Criteria<Item> condition)
        {
            return new AnonymousMatch<Item>(condition);
        }
    }
}

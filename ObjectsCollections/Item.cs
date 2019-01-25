using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectsCollections
{
    public class Item<TKey,TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
        public int Next { get; set; } = -1;

        public Item(TKey key,TValue value)
        {
            Key = key;
            Value = value;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectsCollections
{
    public class Items<TKey,TValue>
    {
        private TKey key { get; set; }
        private TValue value { get; set; }
        private int next { get; set; } = -1;
    }
}

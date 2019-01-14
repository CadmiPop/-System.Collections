using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectsCollections
{
    public class LinkedListNode<T>
    {
        public T Data { get; set; }

        public LinkedListNode(T data)
        {
            Data = data;
        }

        public LinkedListNode<T> Next { get; set; }
        public LinkedListNode<T> Previous { get; set; }
    }
}

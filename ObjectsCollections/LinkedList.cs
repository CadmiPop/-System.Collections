﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ObjectsCollections
{
    class LinkedList<T> : ICollection<T>
    {
        public int Count { get; protected set; }

        public bool IsReadOnly => throw new NotImplementedException();

        private LinkedListNode<T> head;

        public LinkedList()
        {
            head = new LinkedListNode<T>(default(T));
        }

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public void Clear()
        {
            throw new NotImplementedException();
        }

        public bool Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T item)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}

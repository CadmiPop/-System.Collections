using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace ObjectsCollections
{
    public class LinkedList<T> : ICollection<T>
    {
        public int Count { get; protected set; }

        public bool IsReadOnly => false;

        private LinkedListNode<T> head;

        public LinkedList()
        {
            head = new LinkedListNode<T>();
            head.Next = head;
            head.Previous = head;
        }

        void ICollection<T>.Add(T item)
        {
            AddLast(item);
        }

        public void AddFirst(T element)
        {
            var node = new LinkedListNode<T>(element);
            InsertBefore(head.Next, node);
        }

        public void AddLast(T element)
        {
            var node = new LinkedListNode<T>(element);
            InsertBefore(head, node);
        }

        public void InsertBefore(LinkedListNode<T> node , LinkedListNode<T> newNode)
        {
            newNode.Next = node;
            newNode.Previous = node.Previous;
            node.Previous.Next = newNode;
            node.Previous = newNode;
            Count++;
        }

        public void InsertAfter(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {
            AddLast(newNode.Data);
        }

        public void Clear()
        {
            Count = 0;
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
            var current = head;
            if (current != null)
            {
                do
                {
                    yield return current.Data;
                    current = current.Next;
                } while (current != head);
            }
        }

        public IEnumerator<T> GetReverseEnumerator()
        {
            var current = head;
            if (current != null)
            {
                do
                {
                    yield return current.Data;
                    current = head.Previous;
                } while (current != head);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
     
    }
}

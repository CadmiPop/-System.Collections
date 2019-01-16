using System;
using System.Collections;
using System.Collections.Generic;

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
            LinkedListNode<T> node = new LinkedListNode<T>(element);
            InsertBefore(head.Next, node);
        }

        public void AddLast(T element)
        {
            LinkedListNode<T> node = new LinkedListNode<T>(element);
            InsertBefore(head, node);
        }

        public void InsertBefore(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {
            newNode.Next = node;
            newNode.Previous = node.Previous;
            node.Previous.Next = newNode;
            node.Previous = newNode;
            Count++;
        }

        public void InsertAfter(LinkedListNode<T> node, LinkedListNode<T> newNode)
        {
            InsertBefore(node.Next, newNode);
        }

        public LinkedListNode<T> Find(T item)
        {
            for (var current = head.Next; current != head; current = current.Next)
            {
                if(current.Data.Equals(item))
                    return current;
            }
            return null;
        }

        public LinkedListNode<T> FindLast(T item)
        {
            for (var current = head.Previous; current != head; current = current.Previous)
            {
                if (current.Data.Equals(item))
                    return current;
            }
            return null;
        }

        public void Clear()
        {
            Count = 0;
        }

        public bool Contains(T item)
        {
            return Find(item) != null;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array == null)
                throw new ArgumentNullException("Array");
            if (arrayIndex < 0 || arrayIndex > array.Length)
                throw new ArgumentOutOfRangeException("ArrayIndex");

            for (var current = head.Next; current != head; current = current.Next)
            {
                array[arrayIndex] = current.Data;
                arrayIndex++;
            }
        }

        public bool RemoveNode(LinkedListNode<T> nodeToRemove)
        {
            var temp = nodeToRemove.Previous;
            temp.Next = nodeToRemove.Next;
            nodeToRemove.Next.Previous = nodeToRemove.Previous;
            Count--;
            return true;
        }

        public bool Remove(T item)
        {
            var nodeToRemove = Find(item);            
            if  (nodeToRemove == null)
                throw new ArgumentNullException("Node is not in the List");
            if (Contains(item))
            {
                RemoveNode(nodeToRemove);
                return true;
            }
            return false;
        }

        public bool RemoveFirst()
        {
            return RemoveNode(head.Next);
        }

        public bool RemoveLast()
        {
            return RemoveNode(head.Previous);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (var current = head.Next; current != head; current = current.Next)
            {
                yield return current.Data;
            }
        }

        public IEnumerator<T> GetReverseEnumerator()
        {
            for (var current = head.Previous; current != head; current = current.Previous)
            {
                yield return current.Data;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }
}

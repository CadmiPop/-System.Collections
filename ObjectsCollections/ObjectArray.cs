using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks.Dataflow;
using System.Collections;
using System.ComponentModel.Design;
using System.Runtime.CompilerServices;


namespace ObjectsCollections
{
    public class List<T> : IList<T>
    {
        public T [] array;

        public int Count { get; protected set; }

        public bool IsReadOnly => false;

        public T this[int index]
        {
            get => array[index];
            set => array[index] = value;
        }

        public List()
        {
            array = new T[4];
        }

        public virtual void Add(T element)
        {
            ResizeArray();
            array[Count] = element;
            Count++;
        }

        public void ResizeArray()
        {
            if (Count == array.Length)
            {
                Array.Resize(ref array, array.Length * 2);
            }
        }

        public bool Contains(T element)
        {
            return IndexOf(element) != -1;
        }

        public virtual int IndexOf(T element)
        {
            for (int i = 0; i < Count; i++)
            {
                if (array[i].Equals(element))
                    return i;
            }
            return -1;
        }

        public virtual void Insert(int index, T element)
        {           
            ResizeArray();
            for (int i = array.Length - 1; i > index; i--)
            {
                Swap(ref array[i], ref array[i - 1]);
            }
            array[index] = element;
            Count++;
        }

        public static void Swap(ref T v1, ref T v2)
        {
            T temp = v1;
            v1 = v2;
            v2 = temp;
        }

        public void Clear()
        {
            Count = 0;
        }

        public bool Remove(T element)
        {
            if (IndexOf(element) != -1)
            {
                RemoveAt(IndexOf(element));
                return true;
            }
            return false;
        }

        public void RemoveAt(int index)
        {
            Count--;
            for (int k = index; k < Count; k++)
            {
                Swap(ref array[k], ref array[k + 1]);
            }
        }


        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < Count; i++)
            {
                yield return array[i];
            }
        }
        
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public void CopyTo(T[] arrayToCopy, int arrayIndex)
        {

            if ((arrayToCopy.Length - arrayIndex) >= Count)
            {
                Array.Copy(array, 0, arrayToCopy, arrayIndex, Count);
            }
            else
            {
                throw new Exception("Error, my friend");
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectsCollections
{
    public class IntArray
    {
        public int [] array;

        public int Count { get; protected set; }

        public int this[int index]
        {
            get => array[index];
            set => array[index] = value;
        }

        public IntArray()
        {
            array = new int [4];
        }

        public virtual void  Add(int element)
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

        public bool Contains(int element)
        {
            return IndexOf(element) != -1;
        }

        public virtual int IndexOf(int element)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == element)
                    return i;
            }
            return -1;
        }

        public virtual void Insert(int index, int element)
        {
            ResizeArray();
            for (int i = array.Length-1; i > index; i--)
            {
                Swap(ref array[i],ref array[i - 1]);
            }
            array[index] = element;
            Count++;
        }

        public void Swap(ref int v1,ref int v2)
        {
            int temp = v1;
            v1 = v2;
            v2 = temp;
        }

        public void Clear()
        {
            Count = 0;
        }

        public void Remove(int element)
        {
            if(IndexOf(element) != -1)
                RemoveAt(element);
        }

        public void RemoveAt(int index)
        {
            Count--;
            for (int k = index; k < Count; k++)
            {
                Swap(ref array[k], ref array[k + 1]);
            }
        }
    }
}

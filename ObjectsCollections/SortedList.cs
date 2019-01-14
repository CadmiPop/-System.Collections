using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectsCollections
{
    public class SortedList<T> : List<T> where T : IComparable<T>
    {
        public override void Add(T element)
        {
            for (int i = 0; i < Count; i++)
            {
                if (element.CompareTo(array[i]) == -1)
                {
                    Insert(i, element);
                    return;
                }
            }
            Insert(Count, element);
        }

        public override void Insert(int index, T element)
        {
            if (Count == 0 && index == 0 ||
                index == 0 && element.CompareTo(array[index]) == -1  ||
                index == Count && (array[index - 1].CompareTo(element) == 0 || array[index - 1].CompareTo(element) == -1) ||
                (element.CompareTo(array[index]) == 0 || element.CompareTo(array[index]) == -1))
            {
                base.Insert(index, element);
            }
            else
            {
                throw new Exception("Error, my friend");
            }
        }

        public override int IndexOf(T element)
        {
            int index = Array.BinarySearch(array, element);
            return index;
        }
    }
}

using System;

namespace ObjectsCollections
{
    public class SortedIntArray : IntArray
    {

        public override void Add(int element)
        {
            for (int i = 0; i < Count; i++)
            {
                if (element < array[i])
                {
                    Insert(i, element);
                    return;
                }
            }
            Insert(Count, element);
        }

        public override void Insert(int index, int element)
        {
            if (Count == 0 && index == 0 ||
                index == 0 && element < array[index] ||
                index == Count && array[index - 1] <= element ||
                element <= array[index])
            {
                base.Insert(index, element);
            }
            else
            {
                throw new Exception("Error, my friend");
            }
        }

        public override int IndexOf(int element)
        {
            int index = Array.BinarySearch(array, element);
            return index;
        }
    }
}

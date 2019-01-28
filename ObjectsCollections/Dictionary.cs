using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Resources;
using System.Text;
using System.Transactions;

namespace ObjectsCollections
{
    public class Dictionary<TKey,TValue>: IDictionary<TKey, TValue>
    {
        private int[] buckets;

        private Item<TKey, TValue>[] items;

        public int firstItemFree = -1;

        public Dictionary(int capacity = 10)
        {
            buckets = new int[capacity];
            items = new Item<TKey, TValue>[capacity];
            for (int i = 0; i < items.Length; i++)
            {
                buckets[i] = -1;
            }
        }

        public TValue this[TKey key]
        {
            get
            {
                if (GetElementIndex(key, out int index))
                {
                    return items[index].Value;
                }
                else
                {
                    throw new KeyNotFoundException("Key is not found");
                }
            }
            set
            {
                if (GetElementIndex(key, out int index))
                {
                    items[index].Value = value;
                }
                else
                {
                    Add(key, value);
                }
            }
        }
        
        public ICollection<TKey> Keys
        {
            get
            {
                var list = new List<TKey>();
                foreach (var item in items)
                {
                    if (item != null)
                        list.Add(item.Key);
                }
                return list;
            }
        }

        public ICollection<TValue> Values
        {
            get
            {
                var list = new List<TValue>();
                foreach (var item in items)
                {
                    if (item != null)
                        list.Add(item.Value);
                }
                return list;
            }
        }

        public int GetBucketIndex(TKey key) 
            => Math.Abs(key.GetHashCode()) % items.Length;

        public bool GetElementIndex(TKey key, out int index)
        {
            return GetElementIndex(key, out index, out int bucketIndex, out int prevItemIndex);
        }

        public bool GetElementIndex(TKey key, out int index, out int bucketIndex, out int prevItemIndex)
        {
            bucketIndex = GetBucketIndex(key);
            prevItemIndex = -1;
            for (index = buckets[bucketIndex]; index != -1; index = items[index].Next)
            {
                if (items[index].Key.Equals(key))
                    return true;
                prevItemIndex = index;
            }

            return false;
        }

        public int Count { get; protected set; }

        public bool IsReadOnly => false;

        public void Add(TKey key, TValue value)
        {
            if (key == null)
                throw new ArgumentNullException("key is null");
            if (ContainsKey(key))
                throw new ArgumentException("An element with the same key already exists in the IDictionary<TKey, TValue>.");
            if (IsReadOnly)
                throw new NotSupportedException("The IDictionary<TKey,TValue> is read-only.");

            var index = GetBucketIndex(key);

            if (firstItemFree != -1)
            {
                var a = firstItemFree;
                var temp = items[firstItemFree].Next;
                items[firstItemFree] = new Item<TKey, TValue>(key, value) { Next = buckets[index] };
                firstItemFree = temp;                
            }
            else
            {
                items[Count] = new Item<TKey, TValue>(key, value) { Next = buckets[index] };               
            }
            buckets[index] = Count;
            Count++;
        }

        public void Add(KeyValuePair<TKey, TValue> item)
        {
            Add(item.Key,item.Value);
        }

        public void Clear()
        {
            Count = 0;
        }

        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return GetElementIndex(item.Key, out int index);
        }

        public bool ContainsKey(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException("key is null");
            return GetElementIndex(key, out int index);
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            if (array == null)
            {
                throw new ArgumentNullException();
            }

            if (arrayIndex < 0 || arrayIndex > array.Length)
            {
                throw new ArgumentOutOfRangeException();
            }

            if (array.Length - arrayIndex < Count)
            {
                throw new MissingManifestResourceException();
            }
            Array.Copy(items, 0, array, arrayIndex, items.Length);
        }

        public bool Remove(TKey key)
        {
            if (key == null)
                throw new ArgumentNullException("key is null");
            if (IsReadOnly)
                throw new NotSupportedException("The IDictionary<TKey,TValue> is read-only.");

            if (!GetElementIndex(key, out int removedItemIndex, out int bucketIndex, out int prevItemIndex))
                return false;

            if (removedItemIndex == buckets[bucketIndex])
            {
                buckets[bucketIndex] = items[removedItemIndex].Next;
            }
            else
            {
                items[prevItemIndex].Next = items[removedItemIndex].Next;
            }
            
            items[removedItemIndex].Next = firstItemFree;
            firstItemFree = removedItemIndex;
            Count--;
            return true;
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
           return Remove(item.Key);
        }

        public bool TryGetValue(TKey key, out TValue value)
        {
            if (key == null)
                throw new ArgumentNullException("key is null");

            if (GetElementIndex(key, out int index))
            {
                value = items[index].Value;
                return true;
            }

            value = default(TValue);
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            var list = new List<KeyValuePair<TKey, TValue>>();
            for (int bucketIndex = 0; bucketIndex <= buckets.Length - 1; bucketIndex++)
            {
                for (int index = buckets[bucketIndex]; index != -1; index = items[index].Next)
                {
                    yield return list[index];
                }
            }
        }
    }
}
        

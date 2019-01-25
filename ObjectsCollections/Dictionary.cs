using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace ObjectsCollections
{
    public class Dictionary<TKey,TValue>: IDictionary<TKey, TValue>
    {
        private int[] buckets;

        private Item<TKey, TValue>[] items;

        public int firstItemFree;

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
                    return default(TValue);
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
            var bucketIndex = GetBucketIndex(key);

            for (index = buckets[bucketIndex]; index != -1; index = items[index].Next)
            {
                if (items[index].Key.Equals(key))
                    return true;
                
            }

            return false;
        }

        public int Count { get; protected set; }

        public bool IsReadOnly => false;

        public void Add(TKey key, TValue value)
        {
            var index = GetBucketIndex(key);

            items[Count] = new Item<TKey, TValue>(key, value) {Next = buckets[index]};
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
            return GetElementIndex(key, out int index);
        }

        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            Array.Copy(items, 0, array, arrayIndex, items.Length);
        }

        public bool Remove(TKey key)
        {
            GetElementIndex(key, out int index);
            int bucketIndex = GetBucketIndex(key);
            if (buckets[bucketIndex] == -1)
            {
                return false;
            }
            else if (items[index].Next == -1)
            {
                if (items[index].Key.Equals(key))
                {
                    items[buckets[bucketIndex]].Next = -1;
                    items[index] = null;
                    Count--;
                    return true;
                }
            }
            else if (items[index].Next != -1)
            {
                if (items[index].Key.Equals(key))
                {
                    buckets[bucketIndex] = items[index].Next;
                    items[index] = null;
                    Count--;
                    return true;
                }
            }




            return false;
        }

        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            throw new NotImplementedException();
        }

        public bool TryGetValue(TKey key, out TValue value)
        {          
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
        

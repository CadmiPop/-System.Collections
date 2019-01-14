using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Text;

namespace ObjectsCollections
{
    public class Enumerator : IEnumerator
    {
        private object[] array;
        private int current = -1;
        public int count;

        public object Current
        {
            get { return array[current]; }
        }

        public Enumerator(object[] array, int count)
        {
            this.array = array;
            this.count = count;
        }

        public bool MoveNext()
        {
            current++;
            return current <= count;
        }

        public void Reset()
        {
            current = -1;
        }
    }
}

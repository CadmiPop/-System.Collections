using System;
using ObjectsCollections;
using Xunit;

namespace TestsFacts
{
    public class IntArrayTests
    {
        [Fact]
        public void Test_CreateANewArray()
        {
            var a = new IntArray();
            a.Add(5);
            var c = a[0];
            Assert.Equal(5, c);
        }

        [Fact]
        public void Test_Validate_CountandContains()
        {
            var a = new IntArray();
            a.Add(1);
            a.Add(1);
            a.Add(3);
            a.Add(1);
            var count = a.Count;
            Assert.True(a.Contains(3));
            Assert.Equal(4,count);
        }

        [Fact]
        public void Test_Validate_ReturnElementFromIndex()
        {
            var a = new IntArray();
            a.Add(1);
            a.Add(1);
            a.Add(3);
            a.Add(1);


        }

        [Fact]
        public void Test_Validate_ReturnIndexOf()
        {
            var a = new IntArray();
            a.Add(1);
            a.Add(1);
            a.Add(3);
            a.Add(1);
            var asa = a.IndexOf(3);
            Assert.Equal(2, asa);
        }

        [Fact]
        public void Test_Insert()
        {
            var a = new IntArray();
            a.Add(1);
            a.Add(1);
            a.Add(3);
            a.Insert(2,4);
            Assert.Equal(4, a[2]);
        }

        [Fact]
        public void Test_Remove()
        {
            var a = new IntArray();
            a.Add(2);
            a.Add(1);
            a.Add(3);
            a.Add(1);
            a.Remove(1);
            a.Add(7);
            Assert.Equal(3, a[1]);
        }

        [Fact]
        public void Test_RemoveAt()
        {
            var a = new IntArray();
            a.Add(1);
            a.Add(2);
            a.Add(1);
            a.Add(4);
            a.RemoveAt(2);
            a.Add(2);
            Assert.Equal(4, a[2]);
        }

        [Fact]
        public void Test_Clear()
        {
            var a = new IntArray();
            a.Add(1);
            a.Add(1);
            a.Add(3);
            a.Add(4);
            a.Clear();
            a.Add(4);
            Assert.Equal(4, a[0]);
        }

        [Fact]
        public void Test_IndexPropreties()
        {
            var intArray = new IntArray();
            intArray.Add(1);
            intArray[0] = 2;
            Assert.Equal(2, intArray[0]);
        }
    }
}

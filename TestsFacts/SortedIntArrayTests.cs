using System;
using ObjectsCollections;
using Xunit;

namespace TestsFacts
{
    public class SortedIntArrayTests
    {
        [Fact]
        public void Validate_ASortedArray()
        {
            var a = new SortedIntArray();
            a.Add(5);
            a.Add(0);
            a.Add(2);
            a.Add(6);
            a.Add(3);
            Assert.Equal(2, a[1]);
        }

        [Fact]
        public void Test_Insert()
        {
            var a = new SortedIntArray();

            a.Add(1);
            a.Add(4);
            a.Add(3);

            Assert.Equal(3, a[1]);

        }

        [Fact]
        public void Test_Insert1()
        {
            var a = new SortedIntArray();
            a.Insert(0, 2);
            Assert.Equal(2, a[0]);
        }

        [Fact]
        public void Test_Insert2()
        {
            var a = new SortedIntArray();
            a.Add(1);
            a.Add(3);
            a.Add(2);
            a.Insert(3, 4);
            Assert.Equal(2, a[1]);
            Assert.Equal(3, a[2]);
            Assert.Equal(4, a[3]);
        }

        [Fact]
        public void Test_Insert3()
        {
            var a = new SortedIntArray();
            a.Add(1);
            a.Add(3);
            a.Add(2);
            a.Add(1);
            a.Add(5);
            a.Add(2);
            Assert.Equal(1, a[0]);            
        }

        [Fact]
        public void Test_Insert4()
        {
            var a = new SortedIntArray();
            a.Add(1);
            a.Add(2);
            a.Add(3);
            a.Add(4);
            a.Add(5);
            a.Add(6);
            Assert.Equal(6, a[5]);
        }

    }
}

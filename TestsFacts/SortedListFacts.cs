using System;
using ObjectsCollections;
using Xunit;

namespace TestsFacts
{
    public class SortedListFacts
    {
        [Fact]
        public void Validate_AList()
        {
            var a = new SortedList<int>();
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
            var a = new SortedList<int> {1, 4, 3};
            Assert.Equal(3, a[1]);

        }

        [Fact]
        public void Test_Insert1()
        {
            var a = new SortedList<int>();
            a.Insert(0, 2);
            Assert.Equal(2, a[0]);
        }

        [Fact]
        public void Test_Insert2()
        {
            var a = new SortedList<int>();
            a.Add(1);
            a.Add(3);
            a.Add(2);
            Assert.Equal(2, a[1]);
        }

        [Fact]
        public void Test_Insert3()
        {
            var a = new SortedList<int>() {1, 3, 2, 1, 5, 2};
            Assert.Equal(1, a[0]);
        }

        [Fact]
        public void Test_Insert4()
        {
            var a = new SortedList<int> {1, 2, 3, 4, 5, 6};
            Assert.Equal(6, a[5]);
        }

        [Fact]
        public void Test_Insert5()
        {
            var a = new SortedList<string> { "as", "aab", "sabc", "s", };
            Assert.Equal("aab", a[0]);
        }
    } 
}

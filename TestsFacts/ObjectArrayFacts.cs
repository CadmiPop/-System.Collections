using System;
using ObjectsCollections;
using Xunit;

namespace TestsFacts
{
    public class ObjectArrayFacts
    {
        [Fact]
        public void Test_Add_ObjectArray()
        {
            var a = new List<int>{ 1, 3, 1 ,3};
            Assert.Equal(1, a[2]);
        }

        [Fact]
        public void Test_Contains_ObjectArray()
        {
            var a = new List<string>{ "sadsada" , "lol" };
            Assert.Contains("lol", a);
        }

        [Fact]
        public void Test_Insert_ObjectArray()
        {
            var a = new List<string> { "sadsada", "lol" };
            a.Insert(2, "haha");
            Assert.Contains("haha", a);
        }

        [Fact]
        public void Test_Remove_ObjectArray()
        {
            var a = new List<string> { "sadsada", "lol" };
            a.Remove("sadsada");
            Assert.Equal("lol", a[0]);
        }

        [Fact]
        public void Test_RemoveAt_ObjectArray()
        {
            var a = new List<int> { 1, 0, 3, 1, 0, 3 };
            Assert.Equal(new int[] {1, 0, 3, 1, 0, 3}, a);
        }

        [Fact]
        public void Test_IEnumerable()
        {
            var a = new List<int> { 1, 2, 3, 4, 5 };
           
            Assert.Equal(2, a[1]);
        }
    }
}

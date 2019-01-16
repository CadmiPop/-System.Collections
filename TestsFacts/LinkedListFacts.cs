using System;
using ObjectsCollections;
using Xunit;

namespace TestsFacts
{
    public class LinkedListFacts
    {
        [Fact]
        public void Validate_ALinkedList_InsertAfter()
        {
            var a = new LinkedList<int>();
            a.AddLast(4);
            a.AddLast(5);
            a.AddLast(6);
            a.Find(4);
            Assert.Equal(new[] { 4, 5, 6 }, a);
        }

        [Fact]
        public void Validate_ALinkedList_InsertBefore()
        {
            var a = new LinkedList<int>();
            a.AddLast(4);
            a.AddLast(6);
            
            Assert.Equal(new[] { 4, 6 }, a);
        }

        [Fact]
        public void Validate_LinkedList()
        {
            var a = new LinkedList<int>();
            a.AddFirst(2);
            a.AddFirst(4);
            a.AddFirst(6);
            Assert.Equal(new [] {6, 4, 2}, a);
        }
    }
}

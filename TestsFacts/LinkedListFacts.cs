using System;
using ObjectsCollections;
using Xunit;

namespace TestsFacts
{
    public class LinkedListFacts
    {
        [Fact]
        public void Validate_ALinkedList()
        {
            var a = new LinkedList<int>();
            a.AddLast(4);
            a.InsertAfter(new LinkedListNode<int>(4), new LinkedListNode<int>(5));
            a.AddLast(6);
            Assert.Equal(3, a.Count);
        }

        [Fact]
        public void Validate_LinkedList()
        {
            var a = new LinkedList<int>();
            a.AddFirst(2);
            a.AddFirst(4);
            a.AddFirst(6);
            Assert.Equal(3 , a.Count);
        }
    }
}

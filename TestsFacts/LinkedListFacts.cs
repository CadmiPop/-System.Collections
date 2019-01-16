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
            a.InsertBefore(a.Find(4), new LinkedListNode<int>(3));
            Assert.Equal(new[] { 3, 4, 5, 6 }, a);
        }

        [Fact]
        public void Validate_ALinkedList_InsertBefore()
        {
            var a = new LinkedList<int>();
            a.AddLast(4);
            a.AddLast(6);
            a.InsertBefore(a.Find(6), new LinkedListNode<int>(5));
            Assert.Equal(new[] { 4, 5, 6 }, a);
        }

        [Fact]
        public void Validate_LinkedList_AddFirst()
        {
            var a = new LinkedList<int>();
            a.AddFirst(2);
            a.AddFirst(4);
            a.AddFirst(6);
            Assert.Equal(new [] {6, 4, 2}, a);
        }

        [Fact]
        public void Validate_LinkedList_FindLast()
        {
            var a = new LinkedList<int>();
            a.AddFirst(2);
            a.AddFirst(4);
            a.AddFirst(6);
            a.AddFirst(5);
            a.FindLast(5);
            Assert.Equal(new[] { 5, 6, 4, 2 }, a);
        }

        [Fact]
        public void Validate_LinkedList_Contains()
        {
            var a = new LinkedList<int>();
            a.AddFirst(2);
            a.AddFirst(4);
            a.AddFirst(6);
            a.AddFirst(5);
            Assert.Contains(6, a);
        }

        [Fact]
        public void Validate_LinkedList_CopyTo()
        {
            var a = new LinkedList<int>();
            var b = new int[5];
            a.AddFirst(6);
            a.AddFirst(5);
            a.AddFirst(4);
            a.AddFirst(3);
            a.CopyTo(b,1);
            Assert.Equal(new [] {0,3,4,5,6}, b);
        }
    }
}

using System;
using System.Collections.Generic;
using ObjectsCollections;
using Xunit;

namespace TestsFacts
{
    public class DictionaryFacts
    {
        [Fact]
        public void Is_empty_at_start()
        {
            var a = new ObjectsCollections.Dictionary<int, string>();
            Assert.Equal(0, a.Count);
        }

        [Fact]
        public void Keeps_a_new_element()
        {
            // given
            var a = new ObjectsCollections.Dictionary<int, string>();
            // when
            a.Add(1, "test");
            // then
            Assert.True(a.ContainsKey(1));
        }

        [Fact]
        public void Hadles_keys_conflicts()
        {
            // given
            var a = new ObjectsCollections.Dictionary<int, string>(10);
            a.Add(1, "test");
            // when
            a.Add(11, "test1");
            // then
            Assert.True(a.ContainsKey(1));
            Assert.True(a.ContainsKey(11));
            Assert.False(a.ContainsKey(21));
            Assert.Equal(2, a.Count);
        }

        [Fact]
        public void Get_the_value_from_a_Key()
        {
            var a = new ObjectsCollections.Dictionary<int, string>(10);
            a.Add(1, "test");
            a.Add(11, "test1");
            Assert.True(a.TryGetValue(11 , out string value));
        }

        [Fact]
        public void Keeps_a_new_KeyValuePair_element()
        {

            var a = new ObjectsCollections.Dictionary<int, string>(10);
            var b = new KeyValuePair<int,string>(1, "2");
            a.Add(b);

            Assert.Single(a);
        }

        [Fact]
        public void Contains_KeyValuePair_element()
        {

            var a = new ObjectsCollections.Dictionary<int, string>(10);
            var b = new KeyValuePair<int, string>(1, "2");
            a.Add(b);
            Assert.Contains(b, a);
        }

        [Fact]
        public void Remove_element_at_start_position_of_bucket()
        {

            var a = new ObjectsCollections.Dictionary<int, string>(5);
            a.Add(1, "test1");
            a.Add(2, "test2");
            a.Add(10, "test3");
            a.Add(7, "test3");
            a.Remove(2);
            Assert.Equal(3, a.Count);
        }

        [Fact]
        public void Remove_element_at_end_position_of_bucket()
        {

            var a = new ObjectsCollections.Dictionary<int, string>(5);
            a.Add(1, "test1");
            a.Add(2, "test2");
            a.Add(10, "test3");
            a.Add(7, "test3");
            a.Remove(7);
            Assert.Equal(3, a.Count);
        }

        [Fact]
        public void Remove_element_from_middle_of_bucket()
        {

            var a = new ObjectsCollections.Dictionary<int, string>(5);
            a.Add(1, "test1");
            a.Add(2, "test2");
            a.Add(7, "test3");
            a.Add(12,"test12");
            a.Add(17, "test17");
            a.Remove(7);
            Assert.Equal(3, a.Count);
        }
    }
}

using System;
using ObjectsCollections;
using Xunit;

namespace TestsFacts
{
    public class ListFacts
    {
        [Fact]
        public void Validate_AList()
        {
            var a = new List<int> {5,0,2,6,3};
            var b = new int[100];
            a.CopyTo(b,5);
            Assert.Equal(5, b[5]);
        }

        
    }
}

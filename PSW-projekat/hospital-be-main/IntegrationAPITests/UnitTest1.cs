using System;
using Xunit;
using IntegrationAPI;
using IntegrationLibrary.Core.Model;

namespace IntegrationAPITests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            double a = 1;
            double b = 2;
           
            Assert.Equal(3, a+b);
        }
    }
}

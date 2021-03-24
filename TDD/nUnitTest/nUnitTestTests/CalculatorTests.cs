using NUnit.Framework;
using TestingTestFrameworks;

namespace TestingTestFrameworks.Tests
{
    [TestFixture()]
    public class CalculatorTests
    {
        [Test()]
        public void SumTest()
        {
            var c = new Calculator();
            Assert.AreEqual(5, c.Sum(2, 3));
            Assert.AreEqual(-2147483646, c.Sum(int.MaxValue, 3));
            
        }
    }
}
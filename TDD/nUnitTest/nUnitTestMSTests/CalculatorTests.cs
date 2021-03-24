using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestingTestFrameworks;

namespace TestingTestFrameworks.Tests
{
    [TestClass()]
    public class CalculatorTests
    {
        [TestMethod()]
        public void SumTest()
        {
            var c = new Calculator();
            Assert.AreEqual(5, c.Sum(2, 3));
            Assert.AreEqual(-2147483646, c.Sum(int.MaxValue, 3));
        }

        [TestMethod()]
        public void SubtractTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void DivideTest()
        {
            Assert.Fail();
        }

        [TestMethod()]
        public void MultiplyTest()
        {
            Assert.Fail();
        }
    }
}
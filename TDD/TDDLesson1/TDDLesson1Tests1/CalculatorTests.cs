using Microsoft.VisualStudio.TestTools.UnitTesting;

using TDDLesson1;

namespace TDDLesson1.Tests
{
    [TestClass()]
    public class CalculatorTests
    {
        [TestMethod()]
        public void AddTest()
        {
            var calc = new Calculator();
            var valueX = 9;
            var valueY = 10;
            var expected = 19;
            var actual = calc.Add(valueX, valueY);
            Assert.AreEqual(expected, actual);
            Assert.IsTrue(expected == actual);
        }

        [TestMethod()]
        public void AddTestMinus()
        {
            var calc = new Calculator();
            var valueX = -9;
            var valueY = 10;
            var expected = 1;
            var actual = calc.Add(valueX, valueY);
            Assert.AreEqual(expected, actual);
            Assert.IsTrue(expected == actual);
        }
    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;

using TDDLesson1;

namespace TDDLesson1.Tests
{

    [TestClass()]
    public class CalculatorTests
    {


        [TestMethod()]
        public void AddTest_PassWithNumbers()
        {
            var calc = new Calculator();
            var inputA = 4;
            var inputB = 5;
            var actual = calc.Add(inputA, inputB);
            var exprected = 9;
            Assert.AreEqual(exprected, actual);
        }



        [TestMethod()]
        public void AddTest_LotsOfTests()
        {
            var calc = new Calculator();
            Assert.AreEqual(9, calc.Add(4, 5));
            Assert.AreEqual(5, calc.Add(3, 2));
            Assert.AreEqual(102, calc.Add(99, 3));
            Assert.AreEqual(1, calc.Add(-4, 5));
            Assert.AreEqual(5, calc.Add(-4, 9));
        }



    }
}






    /*




        [TestMethod()]
        public void AddTest_PassWithNumbers()
        {
            var calc = new Calculator();
            var inputA = 4;
            var inputB = 5;
            var actual = calc.Add(inputA, inputB);
            var exprected = 9;
            Assert.AreEqual(exprected, actual);
        }

        //[TestMethod()]
        //public void AddTest_TestingFail()
        //{
        //    var calc = new Calculator();
        //    var inputA = 4;
        //    var actual = calc.Add(inputA, null);
        //    var exprected = 4;
        //    Assert.AreEqual(exprected, actual);
        //}

    }
}
    */
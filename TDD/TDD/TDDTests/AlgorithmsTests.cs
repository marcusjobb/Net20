using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDD;

namespace TDD.Tests
{
    [TestClass()]
    public class AlgorithmsTests
    {
        [TestMethod()]
        [DataRow(10, 10, 60)]
        [DataRow(5, 5, 30)]
        [DataRow(6, 4, 10)]
        // En algoritm som tar emot två nummer och returnerar summan
        // Om nummrerna är lika med varandra returnera summan gånger tre
        public void Alg1Test(int a, int b, int expected)
        {
            // Summa kan inte riktigt bli fel så en test räcker
            Assert.AreEqual(expected, Algorithms.Alg1(a, b));
        }

        [TestMethod()]
        [DataRow("Marcus", "MaMaMaMa")]
        [DataRow("Nan", "NaNaNaNa")] // Batman
        // En algoritm som tar emot en sträng och returnerar
        // fyra kopior av de två första bokstäverna från den givna strängen
        public void Alg2Test(string test, string expected)
        {
            Assert.AreEqual(expected, Algorithms.Alg2(test));
        }

        [TestMethod()]
        public void Alg2Test_ShortString()
        {
            try
            {
                Algorithms.Alg2("n");
            }
            catch (Exception ex)
            {
                // Doesn't check for too short string
                Debug.WriteLine(ex.Message);
                Assert.Fail();
            }
        }

        [TestMethod()]
        public void Alg2Test_EmptyString()
        {
            //try
            {

                Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => { Algorithms.Alg2("n"); });
            }
            //catch (Exception ex)
            {
                // Doesn't check for too short string
                //Debug.WriteLine(ex.Message);
                //Assert.Fail();
            }
        }

        [TestMethod()]
        [DataRow("Marcus", "M, s")]
        [DataRow("Dracula", "D, a")]
        [DataRow("Redneck", "R, k")]
        // En algoritm som tar emot en sträng och returnerar första och sista bokstaven
        public void Alg3Test(string data, string expected)
        {
            Assert.AreEqual(expected, Algorithms.Alg3(data));
        }

        [TestMethod()]
        public void Alg3Test_ShortString()
        {
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => 
                { 
                    Algorithms.Alg3(string.Empty); 
                });

            //try
            //{
            //    Algorithms.Alg3(string.Empty);
            //}
            //catch (Exception ex)
            //{
            //    Debug.WriteLine(ex.Message);
            //    Assert.Fail();
            //}
        }

        [TestMethod()]
        [DataRow(0, true)] // Why?
        [DataRow(7, true)]
        [DataRow(8, false)]
        [DataRow(13, true)]
        [DataRow(14, true)]
        [DataRow(15, false)]
        [DataRow(26, true)]
        [DataRow(27, false)]
        // En algoritm som kollar om ett nummer är jämnt delbar med 7 eller 13
        public void Alg4Test(int a, bool expected)
        {
            Assert.AreEqual(expected, Algorithms.Alg4(a));
        }

        [TestMethod()]
        [DataRow(-2, false)]
        [DataRow(0, false)]
        [DataRow(1, false)]
        [DataRow(2, true)]
        [DataRow(4, false)]
        [DataRow(5, true)]
        [DataRow(8, false)]
        [DataRow(11, true)]
        [DataRow(14, false)]
        [DataRow(17, true)]
        [DataRow(20, false)]
        [DataRow(53, true)]
        [DataRow(54, false)]
        [DataRow(89, true)]
        [DataRow(97, true)]
        [DataRow(99, false)]
        // En algoritm som kollar om ett nummer är ett primtal eller inte
        public void Alg5Test(int a, bool expected)
        {
            Assert.AreEqual(expected, Algorithms.Alg5(a));
        }

        [TestMethod()]
        [DataRow("01Fizz", 1, 2, 3)]
        [DataRow("0Fizz23", 7, 9, 2, 4)]
        [DataRow("FizzBuzz", 0)] // WTF
        [DataRow("Fizz", 3)]
        [DataRow("Buzz", 5)]
        [DataRow("Fizz", 6)]
        [DataRow("Buzz", 10)]
        [DataRow("FizzBuzzFizzBuzz", 3,5,6,10)]
        [DataRow("Fizz", -3)]
        [DataRow("Buzz", -5)]
        [DataRow("Fizz", -6)]
        [DataRow("Buzz", -10)]
        [DataRow("012Fizz", 17, 32, 1, 3)]
        public void Alg6Test(string expected, params int[] data)
        {
            Assert.AreEqual(expected, Algorithms.Alg6(data));
        }
    }
}
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestingTheTests;

namespace TestingTheTests.Tests
{
    [TestClass()]
    public class StringHelperTests
    {
        /// <summary>
        /// Positive test
        /// </summary>
        [TestMethod()]
        public void GetWordTest_Rain()
        {
            var testString = "The rain in spain stays mainly in the plain";
            var helper = new StringHelper();
            var actual = helper.GetWord(testString, 1);
            var expected = "rain";
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Empty string, word at position 0, positive
        /// </summary>
        [TestMethod()]
        public void GetWordTest_StringEmpty()
        {
            var testString = "";
            var helper = new StringHelper();
            var actual = helper.GetWord(testString, 0);
            var expected = "";
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Null string, negative test
        /// </summary>
        [TestMethod()]
        public void GetWordTest_StringNull()
        {
            string testString = null;
            var helper = new StringHelper();
            var actual = helper.GetWord(testString, 0);
            var expected = "";
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Position too big, negative test
        /// </summary>
        [TestMethod()]
        public void GetWordTest_RainMax()
        {
            var testString = "The rain in spain stays mainly in the plain";
            var helper = new StringHelper();
            var actual = helper.GetWord(testString, 100);
            var expected = "";
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Gets the word in the first position
        /// </summary>
        [TestMethod()]
        public void GetWordTest_RainFirstPosition()
        {
            var testString = "The rain in spain stays mainly in the plain";
            var helper = new StringHelper();
            var actual = helper.GetWord(testString, 0);
            var expected = "The";
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Try to get a word from a negative index
        /// </summary>
        [TestMethod()]
        public void GetWordTest_RävMinus()
        {
            var testString = "Den spanska räven rev en annan räv";
            var helper = new StringHelper();
            var actual = helper.GetWord(testString, -1);
            var expected = "";
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Try to get a list from a string
        /// </summary>
        [TestMethod()]
        public void StringToListTest()
        {
            var testString = "Den spanska räven rev en annan räv";
            var helper = new StringHelper();
            var actual = string.Join(' ', helper.StringToList(testString));
            var expected = testString;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Try to get a list from a string, with separator char 0
        /// </summary>
        [TestMethod()]
        public void StringToListTest_CharZero()
        {
            var testString = "Den spanska räven rev en annan räv".Replace(' ',(char)0);
            var helper = new StringHelper();
            var actual = string.Join(' ', helper.StringToList(testString, (char)0));
            var expected = "Den spanska räven rev en annan räv";
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Try to get a list from a string, with separator \0
        /// </summary>
        [TestMethod()]
        public void StringToListTest_CharZeroZero()
        {
            var testString = "Den spanska räven rev en annan räv";
            var helper = new StringHelper();
            var actual = string.Join(' ', helper.StringToList(testString, '\0'));
            var expected = testString;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Try to get a list from a string, with separator tab
        /// </summary>
        [TestMethod()]
        public void StringToListTest_CharTab()
        {
            var testString = "Den spanska räven rev en annan räv";
            var helper = new StringHelper();
            var actual = string.Join(' ', helper.StringToList(testString, '\t'));
            var expected = testString;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Try to get a list from a string, with separator char 9, tab
        /// </summary>
        [TestMethod()]
        public void StringToListTest_CharNine()
        {
            var testString = "Den spanska räven rev en annan räv";
            var helper = new StringHelper();
            var actual = string.Join(' ', helper.StringToList(testString, (char)9));
            var expected = testString;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Try to get a list from a string, with separator char 7, Beep
        /// </summary>
        [TestMethod()]
        public void StringToListTest_CharBeep()
        {
            var testString = "Den spanska räven rev en annan räv";
            var helper = new StringHelper();
            var actual = string.Join(' ', helper.StringToList(testString, (char)7));
            var expected = testString;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Try to get a list from a string, with separator char 27, Esc
        /// </summary>
        [TestMethod()]
        public void StringToListTest_CharEsc()
        {
            var testString = "Den spanska räven rev en annan räv";
            var helper = new StringHelper();
            var actual = string.Join(' ', helper.StringToList(testString, (char)27));
            var expected = testString;
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Try to get a list from a string, with lots of spaces
        /// </summary>
        [TestMethod()]
        public void StringToListTestSpacesDeluxe()
        {
            var testString = "Den     spanska      räven    rev   en      annan    räv";
            var helper = new StringHelper();
            var actual = string.Join(' ', helper.StringToList(testString));
            var expected = testString;
            Assert.AreEqual(expected, actual);
        }
        /// <summary>
        /// Try to get a list from a string, with null string
        /// </summary>
        [TestMethod()]
        public void StringToListTest_Null()
        {
            string testString = null;
            var helper = new StringHelper();
            var actual = string.Join(' ', helper.StringToList(testString));
            var expected = "";
            Assert.AreEqual(expected, actual);
        }
    }
}
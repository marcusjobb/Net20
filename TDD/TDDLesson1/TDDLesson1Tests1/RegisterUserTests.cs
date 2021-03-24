using Microsoft.VisualStudio.TestTools.UnitTesting;

using TDDLesson1;

namespace TDDLesson1.Tests
{
    [TestClass()]
    public class RegisterUserTests
    {
        [TestMethod()]
        public void IsPasswordValidTest_IsTooShort()
        {
            // 1 - De ska vara längre än 8 tecken
            var reg = new RegisterUser();
            Assert.IsFalse(reg.IsPasswordValid("1234"));
        }

        [TestMethod()]
        public void IsPasswordValidTest_IsLongEnough()
        {
            // 1 - De ska vara längre än 8 tecken
            var reg = new RegisterUser();
            Assert.IsTrue(reg.IsPasswordValid("123456789"));
        }

        [TestMethod()]
        public void IsPasswordValidTest_IsTooLong()
        {
            // 2 - Får inte vara längre än 50 tecken
            var reg = new RegisterUser();
            Assert.IsTrue(reg.IsPasswordValid("1234567890123456789012345678901234567890"));
        }

        // 3 - Måste innehålla siffror
        // 4 - Måste innehålla Versal
        // 5 - Måste innehålla gemen
        // 6 - Måste innehålla specialtecken +-!%


    }
}
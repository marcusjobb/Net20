namespace LearningMoq.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using LearningMoq;
    using Moq;
    using System.Collections.Generic;

    [TestClass()]
    public class PeopleHelperTests
    {
        private ICrowd Crowd;

        [TestInitialize]
        public void PreparePersonTest()
        {
            var peopleMock = new Mock<IPerson>();
            peopleMock.SetupProperty(n => n.Name, "Jar Jar");
            var person = peopleMock.Object;
            person.Name = person.Name + " Binks";

            var CrowdMock = new Mock<ICrowd>();
            CrowdMock.Setup(c => c.GetName(It.IsAny<int>())).Returns(person);
            CrowdMock.Setup(c => c.GetAge(It.IsAny<string>())).Returns(50);
            CrowdMock.Setup(c => c.People).Returns
                (
                new List<Person>()
                {
                    new Person{Name= "Marcus"},
                    new Person{Name= "Marcelo"},
                }
                );

            Crowd = CrowdMock.Object;
        }

        [TestMethod()]
        public void GetNameTest()
        {
            var actual = Crowd.GetName(1);
            var expected = "Marcus";

            Assert.AreEqual(expected, actual.Name);
        }
        [TestMethod()]
        public void GetNameList()
        {
            var actual = Crowd.People[1];
            var expected = "Marcelo";
            Assert.AreEqual(expected, actual.Name);
        }

        [TestMethod()]
        public void GetNameAge()
        {
            var actual = Crowd.GetAge("Marcus");
            var expected = 50;
            Assert.AreEqual(expected, actual);
        }
    }
}
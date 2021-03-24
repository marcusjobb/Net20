using NUnit.Framework;
using MoqTesting;
using Moq;

namespace MoqTesting.Tests
{
    [TestFixture()]
    public class PeopleHelperTests
    {
        IPeopleHandler peopleHandler;
        IPeopleHelper peopleHelper;
        IPerson person;
        [SetUp]
        public void Setup()
        {
            var mockPerson = new Mock<IPerson>();
            mockPerson.SetupAllProperties();
            mockPerson.SetupProperty(p => p.Name, "Marcus");
            mockPerson.SetupProperty(p => p.Id, 1337);
            mockPerson.SetupProperty(p => p.BirthDate, new System.DateTime(1970, 6, 20));
            person = (IPerson) mockPerson.Object;

            var mockPeopleHelper = new Mock<IPeopleHelper>();
            mockPeopleHelper.Setup(p => p.GetAge(It.IsAny<IPerson>())).Returns(50);
            peopleHelper = mockPeopleHelper.Object;

            var mockPeopleHandler = new Mock<IPeopleHandler>();
            mockPeopleHandler.Setup(m => m.People).Returns(new System.Collections.Generic.List<IPerson>
            {
                new Person{Name="Marcus"},
                new Person{Name="James Sunderland"},
                new Person{Name="Henry Townsend"},
            });
            mockPeopleHandler.Setup(f => f.FindPerson(It.IsAny<string>())).Returns(new Person { Name = "Pyramid Head" });
            peopleHandler = mockPeopleHandler.Object;
        }

        [Test()]
        public void GetAgeTest()
        {
            //peopleHelper = new PeopleHelper();
            var actual = peopleHelper.GetAge(person);
            var expected = 50;
            Assert.AreEqual(expected, actual);
            Assert.AreEqual("Pyramid Head", peopleHandler.FindPerson("James dark memories").Name);

        }
    }
}
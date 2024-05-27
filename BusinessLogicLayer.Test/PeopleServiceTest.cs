using BusinessLogicLayer.Interface;
using DataAccessLayer.Interface;
using Moq;
using NUnit.Framework;

namespace BusinessLogicLayer.Test;

[TestFixture]
internal class PeopleServiceTest
{
    private const string Name1 = "Name1";
    private const string Name2 = "Name2";
    private const string Address1 = "Address1";
    private const string Address2 = "Address2";

    [Test]
    [Description("Test reading from person repository")]
    public void PersonRepositoryListTest()
    {
        //Arrange
        Mock<IPersonRepository> personRepositoryMock = new();
        personRepositoryMock
            .Setup(repo => repo.List())
            .Returns(() => new[]
            {
                Mock.Of<IPerson>(person => person.Name == Name1 && person.Address == Address1),
                Mock.Of<IPerson>(person => person.Name == Name2 && person.Address == Address2)
            });
        IPersonService personService = new PersonService(personRepositoryMock.Object);

        //Act
        IPerson[] result = personService.GetAllPerson().ToArray();

        //Assert
        Assert.Multiple(() =>
        {
            Assert.That(result[0].Name, Is.EqualTo(Name1));
            Assert.That(result[0].Address, Is.EqualTo(Address1));
            Assert.That(result[1].Name, Is.EqualTo(Name2));
            Assert.That(result[1].Address, Is.EqualTo(Address2));
        });
    }
}
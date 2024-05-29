using System.IO.Abstractions;
using System.IO.Abstractions.TestingHelpers;
using DataAccessLayer.Interface;
using DataAccessLayer.Xml;
using NUnit.Framework;

namespace DataAccessLayer.Test;

[TestFixture]
internal class PersonRepositoryTest
{
    private const string Name1 = "Name1";
    private const string Name2 = "Name2";
    private const string Address1 = "Address1";
    private const string Address2 = "Address2";

    [Test]
    [Description("Test reading xml file")]
    public void PersonRepositoryListTest()
    {
        //Arrange
        IFileSystem fileSystem = new MockFileSystem(new Dictionary<string, MockFileData>
        {
            { "xmlFile.xml", new MockFileData(
                "<?xml version=\"1.0\" encoding=\"utf-8\" ?>\r\n" +
                "<People>\r\n" +
                " <Person>\r\n" +
                $"    <Name>{Name1}</Name>\r\n" +
                $"    <Address>{Address1}</Address>\r\n" +
                "  </Person>\r\n" +
                "  <Person>\r\n" +
                $"    <Name>{Name2}</Name>\r\n" +
                $"    <Address>{Address2}</Address>\r\n" +
                "  </Person>\r\n</People>") }
        });

        IPersonRepository personRepository = new PersonRepository(
            new PersonContext(fileSystem, "xmlFile.xml", 
                new XmlPersonMapper(
                    new BasicXmlReader(fileSystem),
                    new PersonFactory())));
        
        //Act
        IPerson[] result = personRepository.List().ToArray();

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
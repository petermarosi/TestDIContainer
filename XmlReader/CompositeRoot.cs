using System.IO.Abstractions;
using DataAccessLayer.Interface;
using DataAccessLayer.Xml;

namespace DataAccessLayer;

public static class CompositeRoot
{
    public static IPersonRepository CreatePersonRepository(IFileSystem fileSystem)
    {
        return new PersonRepository(
            new PersonContext(fileSystem, "XMLFile1.xml",
                new XmlPersonMapper(
                    new BasicXmlReader(fileSystem))));
    }
}
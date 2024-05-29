using System.IO.Abstractions;
using DataAccessLayer.Interface;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer;

internal class PersonContext
{
    public IEnumerable<IPerson> People { get; }

    public PersonContext(
        IFileSystem fileSystem,
        string relativeFilePath,
        IXmlModelMapper<IPerson> personMapper)
    {
        People = personMapper.GetModels(
            fileSystem.Directory.GetCurrentDirectory() + "/" + relativeFilePath, "Person");
    }

}
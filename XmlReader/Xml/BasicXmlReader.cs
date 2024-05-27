using DataAccessLayer.Interfaces;
using System.IO.Abstractions;
using System.Xml;
using System.Xml.Linq;

namespace DataAccessLayer.Xml;

internal class BasicXmlReader : IBasicXmlReader
{
    private readonly IFileSystem _fileSystem;

    public BasicXmlReader(IFileSystem fileSystem)
    {
        _fileSystem = fileSystem;
    }

    public IEnumerable<XElement> ReadElement(string filePath, string elementName)
    {
        using Stream stream = _fileSystem.File.OpenRead(filePath);
        System.Xml.XmlReader reader = System.Xml.XmlReader.Create(stream);

        reader.MoveToContent();
        reader.Read();
        while (reader is { EOF: false, ReadState: ReadState.Interactive })
        {
            if (reader.NodeType == XmlNodeType.Element && reader.Name.Equals(elementName))
            {
                if (XNode.ReadFrom(reader) is not XElement matchedElement)
                {
                    continue;
                }

                yield return matchedElement;
            }

            reader.Read();
        }
    }
}
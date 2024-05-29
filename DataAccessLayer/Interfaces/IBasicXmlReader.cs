using System.Xml.Linq;

namespace DataAccessLayer.Interfaces;

public interface IBasicXmlReader
{
    IEnumerable<XElement> ReadElement(string filePath, string elementName);
}
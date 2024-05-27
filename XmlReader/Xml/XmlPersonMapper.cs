using DataAccessLayer.Interface;
using DataAccessLayer.Interfaces;
using System.Xml.Linq;

namespace DataAccessLayer.Xml;

internal class XmlPersonMapper : IXmlModelMapper<IPerson>
{
    private readonly IBasicXmlReader _reader;

    public XmlPersonMapper(IBasicXmlReader reader)
    {
        _reader = reader;
    }

    public IQueryable<IPerson> GetModels(string filePath, string modelName)
    {
        IEnumerable<XElement> models = _reader.ReadElement(filePath, modelName);

        return models
            .Select(person => new Person(person.GetValue("Name"), person.GetValue("Address")))
            .AsQueryable();
    }
}
using DataAccessLayer.Interface;
using DataAccessLayer.Interfaces;
using System.Xml.Linq;

namespace DataAccessLayer.Xml;

internal class XmlPersonMapper : IXmlModelMapper<IPerson>
{
    private readonly IBasicXmlReader _reader;
    private readonly IPersonFactory _personFactory;

    public XmlPersonMapper(IBasicXmlReader reader, IPersonFactory personFactory)
    {
        _reader = reader;
        _personFactory = personFactory;
    }

    public IEnumerable<IPerson> GetModels(string filePath, string modelName)
    {
        IEnumerable<XElement> models = _reader.ReadElement(filePath, modelName);

        return models
            .Select(person => _personFactory.CreatePerson(
                person.GetValue("Name"),
                person.GetValue("Address")));
    }
}
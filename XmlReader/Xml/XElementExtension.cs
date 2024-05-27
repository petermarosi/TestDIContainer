using System.Xml.Linq;

namespace DataAccessLayer.Xml;

internal static class XElementExtension
{
    public static string GetValue(this XElement element, string elementName)
    {
        return element.Descendants().First(desc => desc.Name == elementName).Value;
    }
}
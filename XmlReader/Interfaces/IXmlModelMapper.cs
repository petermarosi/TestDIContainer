namespace DataAccessLayer.Interfaces;

public interface IXmlModelMapper<out T> where T : class
{
    IEnumerable<T> GetModels(string filePath, string modelName);
}
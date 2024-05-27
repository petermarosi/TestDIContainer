namespace DataAccessLayer.Interfaces;

public interface IXmlModelMapper<out T> where T : class
{
    IQueryable<T> GetModels(string filePath, string modelName);
}
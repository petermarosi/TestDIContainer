namespace DataAccessLayer.Interface;

public interface IPersonRepository
{
    IEnumerable<IPerson> List();
}
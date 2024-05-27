using DataAccessLayer.Interface;

namespace BusinessLogicLayer.Interface;

public interface IPersonService
{
    List<IPerson> GetAllPerson();
}
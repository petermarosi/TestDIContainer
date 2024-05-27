using BusinessLogicLayer.Interface;
using DataAccessLayer.Interface;

namespace BusinessLogicLayer;

public static class CompositeRoot
{
    public static IPersonService CreatePersonService(IPersonRepository personRepository)
    {
        return new PersonService(personRepository);
    }
}
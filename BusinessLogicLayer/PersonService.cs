using BusinessLogicLayer.Interface;
using DataAccessLayer.Interface;

namespace BusinessLogicLayer;

internal class PersonService : IPersonService
{
    private readonly List<IPerson> _people;

    public PersonService(IPersonRepository personRepository)
    {
        _people = personRepository.List().ToList();
    }

    public List<IPerson> GetAllPerson() => _people;
}
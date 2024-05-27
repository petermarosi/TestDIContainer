using BusinessLogicLayer.Interface;
using DataAccessLayer.Interface;

namespace BusinessLogicLayer;

internal class PersonService : IPersonService
{
    private readonly IPersonRepository _personRepository;

    public PersonService(IPersonRepository personRepository)
    {
        _personRepository = personRepository;
    }

    public List<IPerson> GetAllPerson() => _personRepository.List().ToList();
}
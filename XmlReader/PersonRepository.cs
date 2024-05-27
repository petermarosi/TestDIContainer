using DataAccessLayer.Interface;

namespace DataAccessLayer;

internal class PersonRepository : IPersonRepository
{
    private readonly PersonContext _ctx;

    public PersonRepository(PersonContext ctx)
    {
        _ctx = ctx;
    }

    public IEnumerable<IPerson> List() => _ctx.People;
}
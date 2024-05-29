using DataAccessLayer.Interface;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer;

internal class PersonFactory : IPersonFactory
{
    public IPerson CreatePerson(string name, string address)
    {
        return new Person(name, address);
    }
}
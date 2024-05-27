using DataAccessLayer.Interface;

namespace DataAccessLayer;

internal class Person : IPerson
{
    public string Name { get; }
    public string Address { get; }

    public Person(string name, string address)
    {
        Name = name;
        Address = address;
    }

    public string GetName() => Name;
}
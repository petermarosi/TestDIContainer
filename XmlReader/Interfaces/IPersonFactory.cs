using DataAccessLayer.Interface;

namespace DataAccessLayer.Interfaces;

internal interface IPersonFactory
{
    IPerson CreatePerson(string name, string address);
}
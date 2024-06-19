using CommonServices;
using DataAccessLayer.Interface;
using DataAccessLayer.Interfaces;

namespace DataAccessLayer;

internal class PersonFactoryLoggerDecorator : IPersonFactory
{
    private readonly IPersonFactory _personFactory;
    private readonly ILogger _logger;

    public PersonFactoryLoggerDecorator(IPersonFactory personFactory, ILogger logger)
    {
        _personFactory = personFactory;
        _logger = logger;
    }

    public IPerson CreatePerson(string name, string address)
    {
        IPerson newPerson = _personFactory.CreatePerson(name, address);
        _logger.AddMessage($"{name};{address} person created.");

        return newPerson;
    }
}
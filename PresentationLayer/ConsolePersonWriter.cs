using BusinessLogicLayer.Interface;
using PresentationLayer.Interface;

namespace PresentationLayer;

internal class ConsolePersonWriter : IConsoleWriter
{
    private readonly IPersonService _personService;

    public ConsolePersonWriter(IPersonService personService)
    {
        _personService = personService;
    }

    public void Write()
    {
        _personService.GetAllPerson().ForEach(person => Console.WriteLine(person.Name));
    }
}
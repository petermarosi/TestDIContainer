using BusinessLogicLayer.Interface;
using DataAccessLayer.Interface;
using PresentationLayer.Interface;

namespace PresentationLayer;

internal class ConsolePersonPersonWriter : IConsolePersonWriter
{
    private readonly IPersonService _personService;

    public ConsolePersonPersonWriter(IPersonService personService)
    {
        _personService = personService;
    }

    public void WriteAll(Func<IPerson, string> textFunc)
    {
        _personService.GetAllPerson().ForEach(person => Console.WriteLine(textFunc(person)));
    }
}
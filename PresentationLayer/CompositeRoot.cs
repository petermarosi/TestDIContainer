using BusinessLogicLayer.Interface;
using PresentationLayer.Interface;

namespace PresentationLayer;

public static class CompositeRoot
{
    public static IConsoleWriter CreatePersonConsoleWriter(IPersonService personService)
    {
        return new ConsolePersonWriter(personService);
    }
}
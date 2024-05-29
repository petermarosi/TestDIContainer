using DataAccessLayer.Interface;

namespace PresentationLayer.Interface;

public interface IConsolePersonWriter
{
    void WriteAll(Func<IPerson, string> textFunc);
}
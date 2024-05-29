namespace CommonServices;

public class Logger : ILogger
{
    private readonly List<string> _messages;

    public Logger()
    {
        _messages = new List<string>();
    }

    public void AddMessage(string message)
    {
        _messages.Add(message);
    }

    public void PrintAllMessages()
    {
        _messages.ForEach(Console.WriteLine);
    }
}
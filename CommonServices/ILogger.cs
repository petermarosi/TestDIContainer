namespace CommonServices;

public interface ILogger
{
    void AddMessage(string message);
    void PrintAllMessages();
}
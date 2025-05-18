using ToyRobot.Application.Abstractions;

namespace ToyRobot.Infrastructure;

public class ConsoleOutputWriter : IOutputWriter
{
    public void WriteLine(string message) => Console.WriteLine(message);
}
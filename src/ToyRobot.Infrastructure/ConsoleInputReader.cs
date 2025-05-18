using ToyRobot.Application.Abstractions;

namespace ToyRobot.Infrastructure;

public class ConsoleInputReader : IInputReader
{
    public string ReadLine() => Console.ReadLine() ?? string.Empty;
}
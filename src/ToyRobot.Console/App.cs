using ToyRobot.Application;
using ToyRobot.Application.Abstractions;

namespace ToyRobot.Console;

public class App(IInputReader inputReader, IOutputWriter outputWriter, CommandParser commandParser, CommandFactory commandFactory)
{
    public void Run()
    {
        outputWriter.WriteLine("Toy Robot Simulator");
        outputWriter.WriteLine("Enter commands (PLACE 0,0,NORTH | MOVE | LEFT | RIGHT | REPORT):");

        while (true)
        {
            var commandText = inputReader.ReadLine();

            var parseResult = commandParser.Parse(commandText);
            var command = commandFactory.Create(parseResult);

            command.Execute();

            if (parseResult.CommandType == CommandType.Report)
                break;
        }
    }
}
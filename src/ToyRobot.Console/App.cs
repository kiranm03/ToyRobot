using ToyRobot.Application;

namespace ToyRobot.Console;

public class App(CommandParser commandParser, CommandFactory commandFactory)
{
    public void Run()
    {
        System.Console.WriteLine("Toy Robot Simulator");
        System.Console.WriteLine("Enter commands (PLACE 0,0,NORTH | MOVE | LEFT | RIGHT | REPORT):");

        while (true)
        {
            var commandText = System.Console.ReadLine();

            var parseResult = commandParser.Parse(commandText);
            var command = commandFactory.Create(parseResult);

            command.Execute();

            if (parseResult.CommandType == CommandType.Report)
                break;
        }
    }
}
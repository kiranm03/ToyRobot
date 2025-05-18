using ToyRobot.Application;
using ToyRobot.Domain;

namespace ToyRobot.Console;

public static class Program
{
    public static void Main(string[] args)
    {
        System.Console.WriteLine("Toy Robot Simulator");
        System.Console.WriteLine("Enter commands (PLACE 0,0,NORTH | MOVE | LEFT | RIGHT | REPORT):");

        var table = new Table();
        var robot = new Robot(table);
        var commandParser = new CommandParser();
        var commandFactory = new CommandFactory(robot);

        while (true)
        {
            var commandText = System.Console.ReadLine();
            if (commandText == null)
            {
                break;
            }

            var result = commandParser.Parse(commandText);
            var command = commandFactory.Create(result);
            command.Execute();
            
            if (result.CommandType == CommandType.Report)
                break;
        }
    }
}
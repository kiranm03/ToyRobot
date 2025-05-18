using ToyRobot.Application.Commands;
using ToyRobot.Domain;
using System;

namespace ToyRobot.Application;

public class CommandFactory(Robot robot)
{
    public ICommand Create(ParsedCommand parsedCommand)
    {
        
        return parsedCommand.CommandType switch
        {
            CommandType.Place => CreatePlaceCommand(parsedCommand.RawArgs),
            CommandType.Move => new MoveCommand(robot),
            CommandType.Left => new LeftCommand(robot),
            CommandType.Right => new RightCommand(robot),
            CommandType.Report => new ReportCommand(robot),
            _ => new NoOpCommand()
        };
    }

    private ICommand CreatePlaceCommand(string rawArgs)
    {
        if(string.IsNullOrWhiteSpace(rawArgs)) 
            return new NoOpCommand();
        
        var args = rawArgs.Split(',', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

        if (args.Length != 3 ||
            !int.TryParse(args[0], out var x) ||
            !int.TryParse(args[1], out var y) ||
            !Enum.TryParse<Direction>(args[2], true, out var direction))
        {
            return new NoOpCommand();
        }

        return new PlaceCommand(robot, x, y, direction);
    }
}
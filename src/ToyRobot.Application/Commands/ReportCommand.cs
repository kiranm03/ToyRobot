using ToyRobot.Application.Abstractions;
using ToyRobot.Domain;

namespace ToyRobot.Application.Commands;

public class ReportCommand(Robot robot, IOutputWriter outputWriter)
    : ICommand
{
    public void Execute()
    {
        if (robot is { Direction: not null, Position: not null })
            outputWriter.WriteLine($"{robot.Position},{robot.Direction.ToString()?.ToUpperInvariant()}");
    }
}
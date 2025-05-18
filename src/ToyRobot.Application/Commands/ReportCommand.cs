using ToyRobot.Application.Abstractions;
using ToyRobot.Domain;

namespace ToyRobot.Application.Commands;

public class ReportCommand(Robot robot, IOutputWriter outputWriter)
    : ICommand
{
    public void Execute()
    {
        outputWriter.WriteLine($"{robot.Position},{robot.Direction}");
    }
}
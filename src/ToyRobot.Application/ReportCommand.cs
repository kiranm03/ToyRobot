using ToyRobot.Domain;

namespace ToyRobot.Application;

public class ReportCommand(Robot robot)
    : ICommand
{
    public void Execute()
    {
        Console.WriteLine($"{robot.Position} {robot.Direction}");
    }
}
using ToyRobot.Domain;

namespace ToyRobot.Application.Commands;

public class LeftCommand(Robot robot)
    : ICommand
{
    public void Execute()
    {
        robot.TurnLeft();
    }
}
using ToyRobot.Domain;

namespace ToyRobot.Application;

public class LeftCommand(Robot robot)
    : ICommand
{
    public void Execute()
    {
        robot.TurnLeft();
    }
}
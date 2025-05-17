using ToyRobot.Domain;

namespace ToyRobot.Application;

public class MoveCommand(Robot robot)
    : ICommand
{
    public void Execute()
    {
        robot.Move();
    }
}
using ToyRobot.Domain;

namespace ToyRobot.Application.Commands;

public class MoveCommand(Robot robot)
    : ICommand
{
    public void Execute()
    {
        robot.Move();
    }
}
using ToyRobot.Domain;

namespace ToyRobot.Application.Commands;

public class RightCommand(Robot robot) 
    : ICommand
{
    public void Execute()
    {
        robot.TurnRight();
    }
}
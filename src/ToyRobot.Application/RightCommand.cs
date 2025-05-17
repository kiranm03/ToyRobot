using ToyRobot.Domain;

namespace ToyRobot.Application;

public class RightCommand(Robot robot) 
    : ICommand
{
    public void Execute()
    {
        robot.TurnRight();
    }
}
using ToyRobot.Domain;

namespace ToyRobot.Application.Commands;

public class PlaceCommand(Robot robot, int x, int y, Direction direction)
    : ICommand
{
    public void Execute()
    {
        var position = new Position(x, y);
        robot.Place(position, direction);
    }
}
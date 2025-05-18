using ToyRobot.Domain;

namespace ToyRobot.Application.Commands;

public class PlaceCommand(Robot robot, Position position, Direction direction, Table table)
    : ICommand
{
    public void Execute()
    {
        robot.Place(position, direction, table);
    }
}
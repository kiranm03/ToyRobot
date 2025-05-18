namespace ToyRobot.Domain;

public enum Direction
{
    North,
    East,
    South,
    West
}

public static class DirectionExtensions
{
    public static Direction TurnLeft(this Direction direction) => direction switch
    {
        Direction.North => Direction.West,
        Direction.East => Direction.North,
        Direction.South => Direction.East,
        Direction.West => Direction.South,
        _ => direction
    };

    public static Direction TurnRight(this Direction direction) => direction switch
    {
        Direction.North => Direction.East,
        Direction.East => Direction.South,
        Direction.South => Direction.West,
        Direction.West => Direction.North,
        _ => direction
    };
}
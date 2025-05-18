namespace ToyRobot.Domain;

public readonly record struct Position(int X, int Y)
{
    public override string ToString() => $"{X},{Y}";
    
    public Position Move(Direction direction) => direction switch
    {
        Direction.North => new Position(X, Y + 1),
        Direction.East => new Position(X + 1, Y),
        Direction.South => new Position(X, Y - 1),
        Direction.West => new Position(X - 1, Y),
        _ => this
    };
}
namespace ToyRobot.Domain;

public readonly record struct Table
{
    private const int Width = 5;
    private const int Height = 5;
    
    public bool IsValidPosition(Position position) => position is { X: >= 0 and < Width, Y: >= 0 and < Height };
}
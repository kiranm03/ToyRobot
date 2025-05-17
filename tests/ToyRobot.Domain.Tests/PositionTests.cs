namespace ToyRobot.Domain.Tests;

public class PositionTests
{
    private readonly Position _position = new(2, 2);

    [Theory]
    [InlineData(Direction.North, 2, 3)]
    [InlineData(Direction.East, 3, 2)]
    [InlineData(Direction.South, 2, 1)]
    [InlineData(Direction.West, 1, 2)]
    public void Move_WithValidDirection_ReturnsNewPosition(Direction direction, int x, int y)
    {
        // Act
        var result = _position.Move(direction);
        // Assert
        Assert.Equal(new Position(x, y), result);
    }
}
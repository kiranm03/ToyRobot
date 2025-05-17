namespace ToyRobot.Domain.Tests;

public class DirectionTests
{
    [Theory]
    [InlineData(Direction.North, Direction.East)]
    [InlineData(Direction.East, Direction.South)]
    [InlineData(Direction.South, Direction.West)]
    [InlineData(Direction.West, Direction.North)]
    public void TurnRight_WithValidDirection_ReturnsNewDirection(Direction direction, Direction expected)
    {
        // Act
        var result = direction.TurnRight();
        // Assert
        Assert.Equal(expected, result);
    }
    
    [Theory]
    [InlineData(Direction.North, Direction.West)]
    [InlineData(Direction.East, Direction.North)]
    [InlineData(Direction.South, Direction.East)]
    [InlineData(Direction.West, Direction.South)]
    public void TurnLeft_WithValidDirection_ReturnsNewDirection(Direction direction, Direction expected)
    {
        // Act
        var result = direction.TurnLeft();
        // Assert
        Assert.Equal(expected, result);
    }
}
namespace ToyRobot.Domain.Tests;

public class RobotTests
{
    private readonly Robot _robot = new();
    private readonly Table _table = new();
    
    [Theory]
    [InlineData(0, 0, Direction.North)]
    [InlineData(1, 2, Direction.East)]
    [InlineData(4, 4, Direction.South)]
    public void Place_WithValidPositionAndDirection_PlaceRobotAtPositionAndDirection(int x, int y, Direction direction)
    {
        // Arrange
        var position = new Position(x, y);
        // Act
        _robot.Place(position, direction, _table);
        // Assert
        Assert.True(_robot.IsPlaced);
        Assert.Equal(position, _robot.Position);
        Assert.Equal(direction, _robot.Direction);
    }
    
    [Theory]
    [InlineData(-1, 0, Direction.North)]
    [InlineData(0, -1, Direction.East)]
    [InlineData(5, 0, Direction.South)]
    [InlineData(0, 5, Direction.West)]
    public void Place_WithInvalidPositionAndDirection_IgnoresCommandAndDoesNotPlaceRobot(int x, int y, Direction direction)
    {
        // Arrange
        var position = new Position(x, y);
        // Act
        _robot.Place(position, direction, _table);
        // Assert
        Assert.False(_robot.IsPlaced);
        Assert.Null(_robot.Position);
        Assert.Null(_robot.Direction);
    }
    
    [Fact]
    public void Move_WhenRobotIsNotPlaced_DoesNotMoveRobot()
    {
        // Act
        _robot.Move();
        // Assert
        Assert.False(_robot.IsPlaced);
        Assert.Null(_robot.Position);
        Assert.Null(_robot.Direction);
    }
    
    [Fact]
    public void Move_WhenRobotIsPlaced_MovesRobot()
    {
        // Arrange
        _robot.Place(new Position(0, 0), Direction.North, _table);
        // Act
        _robot.Move();
        // Assert
        Assert.True(_robot.IsPlaced);
        Assert.Equal(new Position(0, 1), _robot.Position);
        Assert.Equal(Direction.North, _robot.Direction);
    }
}
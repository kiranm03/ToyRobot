namespace ToyRobot.Domain.Tests;

public class TableTests
{
    private readonly Table _table = new();

    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 1)]
    [InlineData(4, 4)]
    [InlineData(2, 3)]
    public void IsValidPosition_WithValidPosition_ReturnsTrue(int x, int y)
    {
        // Arrange
        var position = new Position(x, y);
        // Act
        var result = _table.IsValidPosition(position);
        // Assert
        Assert.True(result);
    }
    
    [Theory]
    [InlineData(-1, 0)]
    [InlineData(0, -1)]
    [InlineData(5, 0)]
    [InlineData(0, 5)]
    public void IsValidPosition_WithInvalidPosition_ReturnsFalse(int x, int y)
    {
        // Arrange
        var position = new Position(x, y);
        // Act
        var result = _table.IsValidPosition(position);
        // Assert
        Assert.False(result);
    }
}
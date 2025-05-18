using ToyRobot.Application.Commands;
using ToyRobot.Domain;
using ToyRobot.Infrastructure;

namespace ToyRobot.Application.Tests;

public class CommandFactoryTests
{
    private readonly CommandFactory _commandFactory;

    public CommandFactoryTests()
    {
        var robot = new Robot(new Table());
        _commandFactory = new CommandFactory(robot, new ConsoleOutputWriter());
    }

    [Theory]
    [InlineData(CommandType.Left, typeof(LeftCommand))]
    [InlineData(CommandType.Move, typeof(MoveCommand))]
    [InlineData(CommandType.Right, typeof(RightCommand))]
    [InlineData(CommandType.Report, typeof(ReportCommand))]
    [InlineData(CommandType.Invalid, typeof(NoOpCommand))]
    public void Create_WithValidParsedCommand_ReturnsCorrectCommand(CommandType commandType, Type expectedCommandType)
    {
        // Arrange
        var parseResult = new ParseResult(commandType);
        // Act
        var command = _commandFactory.Create(parseResult);
        // Assert
        Assert.IsType(expectedCommandType, command);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData(null)]
    [InlineData("0,0,")]
    [InlineData("0,0,NOR")]
    [InlineData("0,0,NORTH,EAST")]
    [InlineData("0,0,invalid")]
    [InlineData("invalid,invalid,invalid")]
    public void Create_WithInvalidPlaceArgs_ReturnsNoOpCommand(string args)
    {
        // Arrange
        var parseResult = new ParseResult(CommandType.Place, args);
        // Act
        var command = _commandFactory.Create(parseResult);
        // Assert
        Assert.IsType<NoOpCommand>(command);
    }
}
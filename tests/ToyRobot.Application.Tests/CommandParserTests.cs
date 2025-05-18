namespace ToyRobot.Application.Tests;

public class CommandParserTests
{
    private readonly CommandParser _commandParser = new();

    [Theory]
    [InlineData("PLACE 0,0,NORTH", CommandType.Place)]
    [InlineData("MOVE", CommandType.Move)]
    [InlineData("LEFT", CommandType.Left)]
    [InlineData("RIGHT", CommandType.Right)]
    [InlineData("REPORT", CommandType.Report)]
    public void Parse_WithValidInput_ReturnsCorrectCommandType(string input, CommandType expectedCommandType) 
        => Assert.Equal(expectedCommandType, _commandParser.Parse(input).CommandType);
    
    [Theory]
    [InlineData("PLAC 0,0,NORTH")]
    [InlineData("MOV")]
    [InlineData("TEST")]
    [InlineData("")]
    [InlineData(null)]
    [InlineData(" ")]
    public void Parse_WithInvalidInput_ReturnsInvalidCommandType(string input) 
        => Assert.Equal(CommandType.Invalid, _commandParser.Parse(input).CommandType);
}
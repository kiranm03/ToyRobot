using Moq;
using ToyRobot.Application.Abstractions;
using static ToyRobot.Integration.Tests.TestHelper;

namespace ToyRobot.Integration.Tests;

public class IntegrationTests
{
    public static IEnumerable<object[]> CommandScenarios => new List<object[]>
    {
        new object[]
        {
            new[] { "PLACE 0,0,NORTH", "REPORT" },
            new[] { "0,0,NORTH" }
        },
        new object[]
        {
            new[] { "PLACE 0,0,NORTH", "MOVE", "REPORT" },
            new[] { "0,1,NORTH" }
        },
        new object[]
        {
            new[] { "PLACE 0,0,NORTH", "LEFT", "REPORT" },
            new[] { "0,0,WEST" }
        },
        new object[]
        {
            new[] { "PLACE 0,0,NORTH", "RIGHT", "REPORT" },
            new[] { "0,0,EAST" }
        },
        new object[]
        {
            new[] { "PLACE 1,2,EAST", "MOVE", "MOVE", "LEFT", "MOVE", "REPORT" },
            new[] { "3,3,NORTH" }
        }
    };
    
    private void SetupInputSequence(Mock<IInputReader> readerMock, string[] commands)
    {
        var sequence = readerMock.SetupSequence(r => r.ReadLine());
        commands.Aggregate(sequence, (current, command) => current.Returns(command));
    }

    [Theory]
    [MemberData(nameof(CommandScenarios))]
    public void Test_Command_Scenarios(string[] commands, string[] expectedOutputs)
    {
        // Arrange
        var (app, inputReaderMock, outputWriterMock) = SetupAppWithMocks();
        SetupInputSequence(inputReaderMock, commands);
        // Act
        app.Run();
        // Assert
        foreach (var expectedOutput in expectedOutputs)
        {
            outputWriterMock.Verify(writer => writer.WriteLine(expectedOutput), Times.Once);
        }
    }
}
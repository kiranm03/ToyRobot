using Microsoft.Extensions.DependencyInjection;
using Moq;
using ToyRobot.Application;
using ToyRobot.Application.Abstractions;
using ToyRobot.Domain;
using ToyRobot.Console;

namespace ToyRobot.Integration.Tests;

public static class TestHelper
{
    public static (App app, Mock<IInputReader> inputReaderMock, Mock<IOutputWriter> outputWriterMock) SetupAppWithMocks()
    {
        var services = new ServiceCollection();
        var table = new Table();
        var robot = new Robot(table);

        var inputReaderMock = new Mock<IInputReader>();
        var outputWriterMock = new Mock<IOutputWriter>();
        outputWriterMock.Setup(writer => writer.WriteLine(It.IsAny<string>()));

        services.AddSingleton(robot);
        services.AddSingleton<CommandParser>();
        services.AddSingleton<CommandFactory>();
        services.AddSingleton<IInputReader>(_ => inputReaderMock.Object);
        services.AddSingleton<IOutputWriter>(_ => outputWriterMock.Object);
        services.AddSingleton<App>();

        var provider = services.BuildServiceProvider();
        var app = provider.GetRequiredService<App>();

        return (app, inputReaderMock, outputWriterMock);
    }
}
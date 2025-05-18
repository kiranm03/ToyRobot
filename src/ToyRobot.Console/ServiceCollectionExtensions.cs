using Microsoft.Extensions.DependencyInjection;
using ToyRobot.Application;
using ToyRobot.Application.Abstractions;
using ToyRobot.Domain;
using ToyRobot.Infrastructure;

namespace ToyRobot.Console;

public static class ServiceCollectionExtensions
{
    public static void AddToyRobotServices(this IServiceCollection services)
    {
        var table = new Table();
        var robot = new Robot(table);

        services.AddSingleton(robot);
        services.AddSingleton<CommandParser>();
        services.AddSingleton<CommandFactory>();
        services.AddSingleton<IInputReader, ConsoleInputReader>();
        services.AddSingleton<IOutputWriter, ConsoleOutputWriter>();
        services.AddSingleton<App>();
    }
}
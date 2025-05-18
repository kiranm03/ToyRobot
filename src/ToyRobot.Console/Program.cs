using Microsoft.Extensions.DependencyInjection;
using ToyRobot.Application;
using ToyRobot.Console;
using ToyRobot.Domain;
using ToyRobot.Infrastructure;

var services = new ServiceCollection();
services.AddToyRobotServices();

var provider = services.BuildServiceProvider();
var app = provider.GetRequiredService<App>();

app.Run();
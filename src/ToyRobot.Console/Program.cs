using Microsoft.Extensions.DependencyInjection;
using ToyRobot.Application;
using ToyRobot.Console;
using ToyRobot.Domain;

var services = new ServiceCollection();

var table = new Table();
var robot = new Robot(table);

services.AddSingleton(robot);
services.AddSingleton<CommandParser>();
services.AddSingleton<CommandFactory>();
services.AddSingleton<App>();

var provider = services.BuildServiceProvider();
var app = provider.GetRequiredService<App>();

app.Run();
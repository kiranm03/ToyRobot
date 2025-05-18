namespace ToyRobot.Application;

public class CommandParser
{
    public ParsedCommand Parse(string input)
    {
        if (string.IsNullOrWhiteSpace(input)) 
            return ParsedCommand.Invalid;
        
        var inputParts = input.Trim().Split(' ', 2);
        var commandText = inputParts[0];
        var rawArgs = inputParts.Length > 1 ? inputParts[1] : string.Empty;

        if (!Enum.TryParse<CommandType>(commandText,true, out var commandType))
            commandType = CommandType.Invalid;

        return new ParsedCommand(commandType, rawArgs);
    }
}

public readonly record struct ParsedCommand(CommandType CommandType, string RawArgs = "")
{
    public static ParsedCommand Invalid => new(CommandType.Invalid);
}

public enum CommandType
{
    Place,
    Move,
    Left,
    Right,
    Report,
    Invalid
}
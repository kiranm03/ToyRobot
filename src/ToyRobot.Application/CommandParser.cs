namespace ToyRobot.Application;

public class CommandParser
{
    public ParseResult Parse(string? input)
    {
        if (string.IsNullOrWhiteSpace(input)) 
            return ParseResult.Invalid;
        
        var inputParts = input.Trim().Split(' ', 2, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
        var commandText = inputParts[0];
        var rawArgs = inputParts.Length > 1 ? inputParts[1] : string.Empty;

        if (!Enum.TryParse<CommandType>(commandText,true, out var commandType))
            commandType = CommandType.Invalid;

        return new ParseResult(commandType, rawArgs);
    }
}

public readonly record struct ParseResult(CommandType CommandType, string RawArgs = "")
{
    public static ParseResult Invalid => new(CommandType.Invalid);
}
using CommandLineParser.Arguments;

namespace GymManager.Common;

public class Args
{
    public ValueArgument<string> Provider = new('p', "provider", "Database Provider");
    private readonly CommandLineParser.CommandLineParser _parser = new();

    public Args(string[] args)
    {
        _parser.ParseCommandLine(args);

        var argProvider = new ValueArgument<string>('p', "provider", "Database Provider");

        _parser.Arguments.Add(argProvider);
    }
}
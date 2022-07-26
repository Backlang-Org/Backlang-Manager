using CommandLine;
using Dotnet_Tool.Commands;
using Dotnet_Tool.Core;

namespace Dotnet_Tool;

public class Program
{
    public static void Main(string[] args)
    {
        Parser.Default
                .ParseArguments<UpdateSdkCommand, UpdateTemplatesCommand, InstallCommand, PluginsCommand>(args)
                .WithParsed<ICommand>(t => t.Execute())
                .WithNotParsed(PrintError);
    }

    private static void PrintError(IEnumerable<Error> errors)
    {
        foreach (var err in errors)
        {
            Console.WriteLine(err.ToString());
        }
    }
}
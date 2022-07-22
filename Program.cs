using CommandLine;
using Dotnet_Tool.Commands;
using Dotnet_Tool.Core;

namespace Dotnet_Tool;

public class Program
{
    static void Main(string[] args)
    {
        Parser.Default
                .ParseArguments<UpdateSdkCommand, UpdateTemplatesCommand, InstallCommand>(args)
                .WithParsed<ICommand>(t => t.Execute())
                .WithNotParsed( PrintError);

        Console.ReadLine();
    }

    private static void PrintError(IEnumerable<Error> errors)
    {
        foreach (var err in errors)
        {
            Console.WriteLine(err.ToString());
        }
    }
}

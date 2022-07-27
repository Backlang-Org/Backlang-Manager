using BacklangManager.Commands;
using BacklangManager.Core;
using CommandLine;

namespace BacklangManager;

public class Program
{
    public static void Main(string[] args)
    {
#if DEBUG
        args = new[] { "update-sdk" };
#endif

        Parser.Default
                .ParseArguments<UpdateSdkCommand, UpdateTemplatesCommand, InstallCommand, PluginsCommand>(args)
                .WithParsed<ICommand>(t => t.Execute());
    }

    private static void PrintError(IEnumerable<Error> errors)
    {
        foreach (var err in errors)
        {
            Console.WriteLine(err.ToString());
        }
    }
}
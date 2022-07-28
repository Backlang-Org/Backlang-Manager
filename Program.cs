using BacklangManager.Commands;
using BacklangManager.Core;
using CommandLine;

namespace BacklangManager;

public class Program
{
    public static void Main(string[] args)
    {
        Parser.Default
                .ParseArguments<UpdateSdkCommand, UpdateTemplatesCommand, InstallCommand, PluginsCommand>(args)
                .WithParsed<ICommand>(t => t.Execute());
    }
}
using BacklangManager.Core;
using CommandLine;

namespace BacklangManager.Commands;

[Verb("update-templates", HelpText = "Install/Update The Backlang Templates")]
public class UpdateTemplatesCommand : ICommand
{
    [Option('u', "uninstall", HelpText = "Uninstall the templates")]
    public bool ShouldUninstall { get; set; }

    public void Execute()
    {
        if (ShouldUninstall)
        {
            Console.Write(Utils.RunShellCommand("dotnet new uninstall Backlang.Templates"));

            return;
        }

        Console.Write(Utils.RunShellCommand("dotnet new install Backlang.Templates"));
    }
}
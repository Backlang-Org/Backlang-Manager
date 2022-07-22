using CommandLine;
using Dotnet_Tool.Core;

namespace Dotnet_Tool.Commands;

[Verb("update-templates", HelpText = "Install/Update The Backlang Templates")]
public class UpdateTemplatesCommand : ICommand
{
    [Option('u', "uninstall", HelpText = "Uninstall the templates")]
    public bool ShouldUninstall { get; set; }

    public void Execute()
    {
        if(ShouldUninstall)
        {
            Utils.RunShellCommand("dotnet new --uninstall Backlang.Templates");

            return;
        }

        Utils.RunShellCommand("dotnet new --install Backlang.Templates");
    }
}

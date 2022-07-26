using CommandLine;
using Dotnet_Tool.Core;

namespace Dotnet_Tool.Commands;

[Verb("vscode", HelpText = "Install VS Code Extension")]
public class InstallVsCodeExtensionCommand : ICommand
{
    [Option('u', "uninstall", HelpText = "Uninstall the vscode extension")]
    public bool ShouldUninstall { get; set; }

    public void Execute()
    {
        if (ShouldUninstall)
        {
            Console.Write(Utils.RunShellCommand("code --uninstall-extension furesoft.back --force"));

            return;
        }

        Console.Write(Utils.RunShellCommand("code --install-extension furesoft.back --force"));
    }
}
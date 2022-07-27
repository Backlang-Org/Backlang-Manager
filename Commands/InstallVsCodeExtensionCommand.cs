using BacklangManager.Core;
using CommandLine;

namespace BacklangManager.Commands;

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
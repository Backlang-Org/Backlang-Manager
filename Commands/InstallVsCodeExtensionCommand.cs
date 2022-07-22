using CommandLine;
using Dotnet_Tool.Core;

namespace Dotnet_Tool.Commands;

[Verb("vscode", HelpText = "Install VS Code Extension")]
public class InstallVsCodeExtensionCommand : ICommand
{
    public void Execute()
    {
        Utils.RunShellCommand("code --install-extension furesoft.back --force");
    }
}

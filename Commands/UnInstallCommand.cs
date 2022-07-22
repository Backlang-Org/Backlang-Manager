using CommandLine;
using Dotnet_Tool.Core;

namespace Dotnet_Tool.Commands;

[Verb("uninstall", HelpText = "uninstall sdk/templates")]
public class UnInstallCommand : ICommand
{
    [Option("with-extension")]
    public bool UninstallExtension { get; set; }
    public void Execute()
    {
        new UpdateTemplatesCommand().Execute();
        new UpdateSdkCommand().Execute();

        if (UninstallExtension)
        {
            new InstallVsCodeExtensionCommand().Execute();
        }
    }
}

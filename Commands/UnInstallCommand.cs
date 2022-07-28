using BacklangManager.Core;
using CommandLine;

namespace BacklangManager.Commands;

[Verb("uninstall", HelpText = "uninstall sdk/templates")]
public class UnInstallCommand : ICommand
{
    [Option("with-extension")]
    public bool UninstallExtension { get; set; }

    public void Execute()
    {
        new UpdateTemplatesCommand { ShouldUninstall = true }.Execute();
        new UpdateSdkCommand { ShouldUninstall = true }.Execute();

        if (UninstallExtension)
        {
            new InstallVsCodeExtensionCommand { ShouldUninstall = true }.Execute();
        }
    }
}
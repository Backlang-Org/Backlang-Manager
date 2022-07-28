using BacklangManager.Core;
using CommandLine;

namespace BacklangManager.Commands;

[Verb("install", HelpText = "install sdk/templates")]
public class InstallCommand : ICommand
{
    [Option("with-extension")]
    public bool InstallExtension { get; set; }

    public void Execute()
    {
        new UpdateTemplatesCommand().Execute();
        new UpdateSdkCommand().Execute();

        if (InstallExtension)
        {
            new InstallVsCodeExtensionCommand().Execute();
        }
    }
}
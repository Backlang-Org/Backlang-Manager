using CommandLine;
using Dotnet_Tool.Core;
using System.Diagnostics;

namespace Dotnet_Tool.Commands;

[Verb("init", HelpText = "Init first installation of sdk/templates")]
public class InitCommand : ICommand
{
    [Option("with-extension")]
    public bool InstallExtension { get; set; }
    public void Execute()
    {
        new UpdateTemplatesCommand().Execute();
        new UpdateSdkCommand().Execute();

        if(InstallExtension)
        {
            new InstallVsCodeExtensionCommand().Execute();
        }
    }
}

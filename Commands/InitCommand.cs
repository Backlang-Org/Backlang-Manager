using CommandLine;
using Dotnet_Tool.Core;
using System.Diagnostics;

namespace Dotnet_Tool.Commands;

[Verb("init", HelpText = "Init first installation of sdk/templates")]
public class InitCommand : ICommand
{
    public void Execute()
    {
        new TemplatesCommand().Execute();
        new UpdateSdkCommand().Execute();
    }
}

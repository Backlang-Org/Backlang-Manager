using CommandLine;
using Dotnet_Tool.Core;
using System.Diagnostics;

namespace Dotnet_Tool.Commands;

[Verb("update-templates", HelpText = "Update The Backlang Templates")]
public class UpdateTemplatesCommand : ICommand
{
    public void Execute()
    {
        Utils.RunShellCommand("dotnet new --install Backlang.Templates");
    }
}

using CommandLine;
using Dotnet_Tool.Core;

namespace Dotnet_Tool.Commands;

[Verb("update-sdk", HelpText = "Install/Update The Backlang SDK")]
public class UpdateSdkCommand : ICommand
{
    [Option('u', "uninstall", HelpText = "Uninstall the sdk")]
    public bool ShouldUninstall { get; set; }

    public void Execute()
    {
        if(ShouldUninstall)
        {
            SdkInstaller.Uninstall("Backlang.NET.Sdk");

            return;
        }

        SdkInstaller.Install("Backlang.NET.Sdk");
    }
}

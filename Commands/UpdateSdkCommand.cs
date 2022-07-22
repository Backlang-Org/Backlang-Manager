using CommandLine;
using Dotnet_Tool.Core;
using NuGet.Packaging;

namespace Dotnet_Tool.Commands;

[Verb("update-sdk", HelpText = "Install/Update The Backlang SDK")]
public class UpdateSdkCommand : ICommand
{
    public async void Execute()
    {
        SdkInstaller.Install("Backlang.NET.Sdk");
    }
}

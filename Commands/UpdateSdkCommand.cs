using CommandLine;
using Dotnet_Tool.Core;
using NuGet.Common;
using NuGet.Packaging;
using NuGet.Protocol;
using NuGet.Protocol.Core.Types;
using NuGet.Versioning;
using System.IO.Compression;

namespace Dotnet_Tool.Commands;

[Verb("update-sdk", HelpText = "Install/Update The Backlang SDK")]
public class UpdateSdkCommand : ICommand
{
    public async void Execute()
    {
        var cache = new SourceCacheContext();
        SourceRepository repository = Repository.Factory.GetCoreV3("https://api.nuget.org/v3/index.json");
        FindPackageByIdResource resource = await repository.GetResourceAsync<FindPackageByIdResource>();
        
        var latestVersion = GetLatestVersion(cache, resource);

        DownloadPackage(cache, resource, latestVersion);
    }

    private static void DownloadPackage(SourceCacheContext cache, FindPackageByIdResource resource, NuGetVersion version)
    {
        using MemoryStream packageStream = new MemoryStream();

        resource.CopyNupkgToStreamAsync(
            "Backlang.NET.Sdk",
            version,
            packageStream,
            cache,
            NullLogger.Instance,
            CancellationToken.None).Wait();

        Console.WriteLine($"Downloaded SDK {version}");

        Console.WriteLine("Determine .Net Version");
        var sdkVersions = Utils.RunShellCommand("dotnet --list-sdks")
            .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .Select(_=> _[.._.IndexOf(' ')]);

        var programsPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
        var dotnetSdkPath = Path.Combine(programsPath, @"dotnet\sdk\", sdkVersions.Last(), "Sdks");

        Console.WriteLine("Extract Sdk");
        using var archive = new ZipArchive(packageStream, ZipArchiveMode.Read);

        string sdkPath = Path.Combine(dotnetSdkPath, "Backlang.NET.Sdk");

        archive.ExtractToDirectory(sdkPath, true);

        Console.WriteLine("SDK installed");
    }
    private static NuGetVersion GetLatestVersion(SourceCacheContext cache, FindPackageByIdResource resource)
    {
        return resource.GetAllVersionsAsync(
                    "Backlang.NET.Sdk",
                    cache,
                    NullLogger.Instance,
                    CancellationToken.None).Result.Last();
    }
}

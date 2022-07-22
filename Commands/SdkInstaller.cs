﻿using Dotnet_Tool.Core;
using NuGet.Common;
using NuGet.Protocol;
using NuGet.Protocol.Core.Types;
using NuGet.Versioning;
using System.IO.Compression;

namespace Dotnet_Tool.Commands;

public static class SdkInstaller
{
    public static async void Install(string sdkId)
    {
        var cache = new SourceCacheContext();
        SourceRepository repository = Repository.Factory.GetCoreV3("https://api.nuget.org/v3/index.json");
        FindPackageByIdResource resource = await repository.GetResourceAsync<FindPackageByIdResource>();

        var latestVersion = GetLatestVersion(cache, resource, sdkId);

        DownloadAndInstallPackage(cache, resource, latestVersion, sdkId);
    }

    public static void Uninstall(string sdkId)
    {
        var sdkVersions = GetDotnetSdkVersions();

        var programsPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
        var dotnetSdkPath = Path.Combine(programsPath, @"dotnet\sdk\", sdkVersions.Last(), "Sdks");

        Console.WriteLine("Remove SDK");

        string sdkPath = Path.Combine(dotnetSdkPath, sdkId);

        Utils.DeleteDirectory(sdkPath);
    }

    private static void DownloadAndInstallPackage(SourceCacheContext cache, FindPackageByIdResource resource, NuGetVersion version, string sdkId)
    {
        using MemoryStream packageStream = new MemoryStream();

        resource.CopyNupkgToStreamAsync(
            sdkId,
            version,
            packageStream,
            cache,
            NullLogger.Instance,
            CancellationToken.None).Wait();

        Console.WriteLine($"Downloaded SDK {version}");
        var sdkVersions = GetDotnetSdkVersions();

        var programsPath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
        var dotnetSdkPath = Path.Combine(programsPath, @"dotnet\sdk\", sdkVersions.Last(), "Sdks");

        Console.WriteLine("Extract Sdk");
        using var archive = new ZipArchive(packageStream, ZipArchiveMode.Read);

        string sdkPath = Path.Combine(dotnetSdkPath, sdkId);

        archive.ExtractToDirectory(sdkPath, true);

        Console.WriteLine("SDK installed");
    }

    private static IEnumerable<string> GetDotnetSdkVersions()
    {
        Console.WriteLine("Determine .Net Version");
        var sdkVersions = Utils.RunShellCommand("dotnet --list-sdks")
            .Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries)
            .Select(_ => _[.._.IndexOf(' ')]);
        return sdkVersions;
    }

    private static NuGetVersion GetLatestVersion(SourceCacheContext cache, FindPackageByIdResource resource, string sdkId)
    {
        return resource.GetAllVersionsAsync(
                    sdkId,
                    cache,
                    NullLogger.Instance,
                    CancellationToken.None).Result.Last();
    }
}
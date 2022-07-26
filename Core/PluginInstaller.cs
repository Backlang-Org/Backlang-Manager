using NuGet.Common;
using NuGet.Protocol;
using NuGet.Protocol.Core.Types;
using System.IO.Compression;

namespace Dotnet_Tool.Core;

public static class PluginInstaller
{
    public static async void List()
    {
        var cache = new SourceCacheContext();
        var repository = Repository.Factory.GetCoreV3("https://api.nuget.org/v3/index.json");
        var resource = await repository.GetResourceAsync<PackageSearchResource>();
        var searchFilter = new SearchFilter(includePrerelease: false);

        var result =
             resource.SearchAsync("backlang", searchFilter,
            0, 20, NullLogger.Instance, CancellationToken.None).Result;

        result = result.Where(_ => _.Tags.Contains("backend") || _.Tags.Contains("plugin"));

        foreach (var pck in result)
        {
            Console.WriteLine(pck.Title + " " + pck.GetVersionsAsync().Result.Last().Version);
        }
    }

    public static async void Install(string pckName)
    {
        var cache = new SourceCacheContext();
        SourceRepository repository = Repository.Factory.GetCoreV3("https://api.nuget.org/v3/index.json");
        FindPackageByIdResource resource = await repository.GetResourceAsync<FindPackageByIdResource>();

        var latestVersion = SdkInstaller.GetLatestVersion(cache, resource, pckName);

        var pluginsDir = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "Backlang", "Plugins");

        if (!Directory.Exists(pluginsDir))
        {
            Directory.CreateDirectory(pluginsDir);
        }

        using MemoryStream packageStream = new MemoryStream();

        resource.CopyNupkgToStreamAsync(
            pckName,
            latestVersion,
            packageStream,
            cache,
            NullLogger.Instance,
            CancellationToken.None).Wait();

        using var archive = new ZipArchive(packageStream, ZipArchiveMode.Read);
        var lib = archive.Entries.Where(_ => _.FullName.StartsWith("lib/"));

        foreach (var libItem in lib)
        {
            libItem.ExtractToFile(Path.Combine(pluginsDir, libItem.Name), true);
        }

        Environment.Exit(0);
    }
}
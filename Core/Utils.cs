using System.Diagnostics;

namespace Dotnet_Tool.Core;

public static class Utils
{
    public static string RunShellCommand(string command)
    {
        var spl = command.Split(' ');

        var process = Process.Start(new ProcessStartInfo
        {
            UseShellExecute = false,
            FileName = spl[0],
            RedirectStandardOutput = true,
            Arguments = command[(spl[0].Length + 1)..]
        });

        return process.StandardOutput.ReadToEnd();
    }
}

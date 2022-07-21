using System.Diagnostics;

namespace Dotnet_Tool.Core;

public static class Utils
{
    public static void RunShellCommand(string command)
    {
        var spl = command.Split(' ');

        Process.Start(new ProcessStartInfo
        {
            UseShellExecute = true,
            FileName = spl[0],
            Arguments = command[(spl[0].Length + 1)..]
        });
    }
}

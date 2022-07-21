using System.Diagnostics;
namespace Dotnet_Tool;

public static class Utils
{
    public static void RunShellCommand(string command)
    {
        Process.Start(new ProcessStartInfo
        {
            UseShellExecute = true,
            FileName = @"C:\Windows\System32\cmd.exe",
            Arguments = "/c " + command
        });
    }
}

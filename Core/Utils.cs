using System.Diagnostics;
using System.Runtime.InteropServices;

namespace BacklangManager.Core;

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

    public static void RunWindowsAdminCommand(string command)
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();

            startInfo.Arguments = "/c " + command;
            startInfo.Verb = "runas";
            startInfo.UseShellExecute = true;
            startInfo.FileName = "cmd";

            Process.Start(startInfo);
        }
    }

    public static void DeleteDirectory(string target_dir)
    {
        string[] files = Directory.GetFiles(target_dir);
        string[] dirs = Directory.GetDirectories(target_dir);

        foreach (string file in files)
        {
            File.SetAttributes(file, FileAttributes.Normal);
            File.Delete(file);
        }

        foreach (string dir in dirs)
        {
            DeleteDirectory(dir);
        }

        Directory.Delete(target_dir, false);
    }
}
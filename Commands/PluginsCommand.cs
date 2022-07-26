using CommandLine;
using Dotnet_Tool.Core;

namespace Dotnet_Tool.Commands
{
    [Verb("plugins", HelpText = "Manage Plugins")]
    public class PluginsCommand : ICommand
    {
        [Option('a', "available", HelpText = "List All Available Plugins")]
        public bool Available { get; set; }

        [Option('l', "list", HelpText = "List All Installed Plugins")]
        public bool List { get; set; }

        [Option('i', "install", HelpText = "Install the plugin")]
        public string InstallPackageName { get; set; }

        public void Execute()
        {
            if (Available)
            {
                PluginInstaller.List();
            }
            else if (List)
            {
                var pluginsDir = Path.Combine(
                Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                "Backlang", "Plugins");

                Console.WriteLine("All Installed Plugins:");

                foreach (var file in Directory.GetFiles(pluginsDir, "*.dll"))
                {
                    Console.WriteLine("\t" + Path.GetFileNameWithoutExtension(file));
                }
            }
            else if (!string.IsNullOrEmpty(InstallPackageName))
            {
                PluginInstaller.Install(InstallPackageName);
            }

            Environment.Exit(0);
        }
    }
}
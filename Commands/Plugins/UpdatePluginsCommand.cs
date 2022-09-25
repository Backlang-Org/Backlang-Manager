using BacklangManager.Core;
using BacklangManager.Core.TUI;
using Spectre.Console;

namespace BacklangManager.Commands.Plugins;

public class UpdatePluginsCommand : IMenuCommand
{
    public void Invoke(Menu parentMenu)
    {
        var pluginsDir = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "Backlang", "Plugins");

        if (Directory.Exists(pluginsDir))
        {
            AnsiConsole.Progress().Start(_ => {
                var files = Directory.GetFiles(pluginsDir, "*.dll");

                var task = _.AddTask($"Updating Plugins", maxValue: files.Count());

                for (var i = 0; i < files.Length; i++)
                {
                    var file = files[i];
                    var packageName = Path.GetFileNameWithoutExtension(file);

                    PluginInstaller.Install(packageName);

                    task.Increment(i);
                }
            });
        }
        else
        {
            Console.WriteLine("No Plugins Installed");
        }

        parentMenu.Show();
    }
}
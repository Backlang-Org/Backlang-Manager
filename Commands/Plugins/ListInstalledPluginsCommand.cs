using BacklangManager.Core.TUI;
using Spectre.Console;
using System.Runtime.Loader;

namespace BacklangManager.Commands.Plugins;

public class ListInstalledPluginsCommand : IMenuCommand
{
    public void Invoke(Menu parentMenu)
    {
        var pluginsDir = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "Backlang", "Plugins");

        if (Directory.Exists(pluginsDir))
        {
            Console.WriteLine("All Installed Plugins:");

            var table = new Table();
            table.AddColumns("Name", "Version");

            foreach (var file in Directory.GetFiles(pluginsDir, "*.dll"))
            {
                var assLoadContext = AssemblyLoadContext.Default.LoadFromAssemblyPath(file);

                table.AddRow(new Text(Path.GetFileNameWithoutExtension(file)), new Text(assLoadContext.GetName().Version.ToString()));
            }

            AnsiConsole.Write(table);
        }
        else
        {
            Console.WriteLine("No Plugins Installed");
        }

        parentMenu.WaitAndShow();
    }
}
using BacklangManager.Core;
using BacklangManager.Core.TUI;
using Spectre.Console;

namespace BacklangManager.Commands.Plugins;

public class ListAvailablePluginsCommand : IMenuCommand
{
    public async void Invoke(Menu parentMenu)
    {
        var menu = new Menu(parentMenu);

        AnsiConsole.Status().Start("Loading Available Plugins", _ => {
            foreach (var plugin in PluginInstaller.GetAvailablePlugins().ToBlockingEnumerable())
            {
                //ToDo: add [Installed] if plugin is already installed
                menu.Items.Add(plugin.Title + " " + plugin.Version, new InstallPluginCommand(plugin.Title));
            }
        });

        menu.Show();

        parentMenu.Show();
    }
}
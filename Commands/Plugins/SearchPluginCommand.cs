using BacklangManager.Core;
using BacklangManager.Core.TUI;
using Spectre.Console;

namespace BacklangManager.Commands.Plugins;

public class SearchPluginCommand : IMenuCommand
{
    public async void Invoke(Menu parentMenu)
    {
        var searchTerm = AnsiConsole.Prompt(new TextPrompt<string>("Search for: "));

        var availablePlugins = PluginInstaller.Search(searchTerm);

        var selectionMenu = new Menu(parentMenu);

        await foreach (var plugin in availablePlugins)
        {
            selectionMenu.Items.Add(plugin.Title, new InstallPluginCommand(plugin.Title));
        }

        if (selectionMenu.Items.Count == 0)
            selectionMenu.Items.Add("No Plugins Found", null);

        selectionMenu.Show();
    }
}
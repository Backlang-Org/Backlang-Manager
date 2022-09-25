using BacklangManager.Commands.Plugins;
using BacklangManager.Core.TUI;

namespace BacklangManager.Commands;

public class ManagePluginsCommand : IMenuCommand
{
    public void Invoke(Menu parentMenu)
    {
        var menu = new Menu(parentMenu);
        menu.Items.Add("Update", new UpdatePluginsCommand());
        menu.Items.Add("Search", new SearchPluginCommand());
        menu.Items.Add("List Installed Plugins", new ListInstalledPluginsCommand());
        menu.Items.Add("Install Plugin", new ListAvailablePluginsCommand());
        menu.Items.Add("Remove", new RemovePluginCommand());

        menu.Show();

        parentMenu.Show();
    }
}
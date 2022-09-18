using BacklangManager.Commands.Plugins;
using BacklangManager.Core.TUI;

namespace BacklangManager.Commands;

public class ManagePluginsCommand : IMenuCommand
{
    public void Invoke(Menu parentMenu)
    {
        var menu = new Menu(parentMenu);
        menu.Items.Add("Update", null);
        //menu.Items.Add("Search", null);
        menu.Items.Add("List Installed Plugins", new ListInstalledPluginsCommand());
        menu.Items.Add("Install Plugin", new ListAvailablePluginsCommand());
        menu.Items.Add("Remove", new RemovePluginCommand());

        menu.Show();

        parentMenu.Show();
    }
}
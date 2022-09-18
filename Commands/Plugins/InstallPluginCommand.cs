using BacklangManager.Core;
using BacklangManager.Core.TUI;

namespace BacklangManager.Commands.Plugins;

public class InstallPluginCommand : IMenuCommand
{
    private string _title;

    public InstallPluginCommand(string title)
    {
        _title = title;
    }

    public void Invoke(Menu parentMenu)
    {
        PluginInstaller.Install(_title);

        parentMenu.Show();
    }
}
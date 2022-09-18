using BacklangManager.Core.TUI;

namespace BacklangManager.Commands.Plugins;

public class RemoveSelectedPluginCommand : IMenuCommand
{
    private string _pluginName;

    public RemoveSelectedPluginCommand(string pluginName)
    {
        _pluginName = pluginName;
    }

    public void Invoke(Menu parentMenu)
    {
        var pluginsDir = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "Backlang", "Plugins");

        var pluginFile = Path.Combine(pluginsDir, _pluginName + ".dll");
        File.Delete(pluginFile);

        parentMenu.Items.Remove(_pluginName);

        parentMenu.Show();
    }
}
using BacklangManager.Core.TUI;

namespace BacklangManager.Commands.Plugins;

public class RemovePluginCommand : IMenuCommand
{
    public void Invoke(Menu parentMenu)
    {
        var selection = new Menu(parentMenu);

        var pluginsDir = Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "Backlang", "Plugins");

        foreach (var file in Directory.GetFiles(pluginsDir, "*.dll"))
        {
            var pluginName = Path.GetFileNameWithoutExtension(file);

            selection.Items.Add(pluginName, new RemoveSelectedPluginCommand(pluginName));
        }

        selection.Show();
    }
}
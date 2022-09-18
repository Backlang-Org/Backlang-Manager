using BacklangManager.Commands;
using BacklangManager.Core.TUI;

namespace BacklangManager;

public class Program
{
    public static void Main(string[] args)
    {
        var mainMenu = new Menu(null);
        mainMenu.Items.Add("Manage SDK", new ManageSdkCommand());
        mainMenu.Items.Add("Manage Templates", new ManageTemplatesCommand());
        mainMenu.Items.Add("Manage Plugins", new ManagePluginsCommand());
        mainMenu.Items.Add("Manage VSCode", new ManageVSCodeCommand());

        mainMenu.Items.Add("Exit", new ExitCommand());

        mainMenu.Show();
    }
}
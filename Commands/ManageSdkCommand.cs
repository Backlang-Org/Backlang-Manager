using BacklangManager.Commands.SDK;
using BacklangManager.Core.TUI;

namespace BacklangManager.Commands;

public class ManageSdkCommand : IMenuCommand
{
    public void Invoke(Menu parentMenu)
    {
        var menu = new Menu(parentMenu);
        menu.Items.Add("Install/Update", new InstallSdkCommand());
        menu.Items.Add("Remove", new RemoveSdkCommand());

        menu.Show();

        parentMenu.Show();
    }
}
using BacklangManager.Commands.VSCode;
using BacklangManager.Core.TUI;

namespace BacklangManager.Commands;

public class ManageVSCodeCommand : IMenuCommand
{
    public void Invoke(Menu parentMenu)
    {
        var menu = new Menu(parentMenu);
        menu.Items.Add("Install/Update", new InstallExtensionCommand());
        menu.Items.Add("Remove", new RemoveExtensionCommand());

        menu.Show();

        parentMenu.Show();
    }
}
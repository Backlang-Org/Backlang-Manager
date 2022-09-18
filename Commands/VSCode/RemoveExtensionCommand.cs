using BacklangManager.Core;
using BacklangManager.Core.TUI;

namespace BacklangManager.Commands.VSCode;

public class RemoveExtensionCommand : IMenuCommand
{
    public void Invoke(Menu parentMenu)
    {
        Utils.RunWindowsAdminCommand("code --uninstall-extension furesoft.back --force");

        parentMenu.Show();
    }
}

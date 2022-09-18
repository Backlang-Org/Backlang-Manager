using BacklangManager.Core;
using BacklangManager.Core.TUI;
using Spectre.Console;

namespace BacklangManager.Commands.VSCode;

public class InstallExtensionCommand : IMenuCommand
{
    public void Invoke(Menu parentMenu)
    {
        AnsiConsole.Status().Start("Installing", _ => {
            Utils.RunShellCommand("code --install-extension furesoft.back --force");
        });

        parentMenu.Show();
    }
}
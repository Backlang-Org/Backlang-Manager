using BacklangManager.Commands.SDK;
using BacklangManager.Commands.Templates;
using BacklangManager.Commands.VSCode;
using BacklangManager.Core.TUI;

namespace BacklangManager.Commands;

public class InstallAllCommand : IMenuCommand
{
    public void Invoke(Menu parentMenu)
    {
        new InstallSdkCommand().Invoke(parentMenu);
        new InstallTemplatesCommand().Invoke(parentMenu);
        new InstallExtensionCommand().Invoke(parentMenu);
    }
}
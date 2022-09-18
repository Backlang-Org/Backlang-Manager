using BacklangManager.Core;
using BacklangManager.Core.TUI;

namespace BacklangManager.Commands.SDK;

public class RemoveSdkCommand : IMenuCommand
{
    public void Invoke(Menu parentMenu)
    {
        SdkInstaller.Uninstall("Backlang.NET.Sdk");

        parentMenu.Show();
    }
}
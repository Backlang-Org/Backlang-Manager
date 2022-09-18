using BacklangManager.Core;
using BacklangManager.Core.TUI;

namespace BacklangManager.Commands.SDK;

public class InstallSdkCommand : IMenuCommand
{
    public void Invoke(Menu parentMenu)
    {
        SdkInstaller.Install("Backlang.NET.Sdk");

        parentMenu.Show();
    }
}
using BacklangManager.Core;
using BacklangManager.Core.TUI;

namespace BacklangManager.Commands.Templates;

public class InstallTemplatesCommand : IMenuCommand
{
    public void Invoke(Menu parentMenu)
    {
        Console.Write(Utils.RunCommand("dotnet new install Backlang.Templates"));

        parentMenu.Show();
    }
}
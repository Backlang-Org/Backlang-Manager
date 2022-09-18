using BacklangManager.Core;
using BacklangManager.Core.TUI;

namespace BacklangManager.Commands.Templates;

public class RemoveTemplatesCommand : IMenuCommand
{
    public void Invoke(Menu parentMenu)
    {
        Console.Write(Utils.RunCommand("dotnet new uninstall Backlang.Templates"));

        parentMenu.Show();
    }
}
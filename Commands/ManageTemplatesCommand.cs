using BacklangManager.Commands.Templates;
using BacklangManager.Core.TUI;

namespace BacklangManager.Commands;

public class ManageTemplatesCommand : IMenuCommand
{
    public void Invoke(Menu parentMenu)
    {
        var menu = new Menu(parentMenu);
        menu.Items.Add("Install/Update", new InstallTemplatesCommand());
        menu.Items.Add("Remove", new RemoveTemplatesCommand());

        menu.Show();

        parentMenu.Show();
    }
}
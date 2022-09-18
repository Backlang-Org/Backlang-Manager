using BacklangManager.Core.TUI;

namespace BacklangManager.Commands
{
    public class ExitCommand : IMenuCommand
    {
        public void Invoke(Menu parentMenu)
        {
            Console.Clear();
            Environment.Exit(0);
        }
    }
}
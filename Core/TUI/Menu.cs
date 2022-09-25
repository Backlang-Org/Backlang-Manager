using Spectre.Console;
using System.Text;

namespace BacklangManager.Core.TUI;

public class Menu
{
    public Menu Parent;

    public Menu(Menu parentMenu)
    {
        Parent = parentMenu;
    }

    public Dictionary<string, IMenuCommand> Items { get; set; } = new();

    public void WaitAndShow()
    {
        Console.ReadKey();
        Show();
    }

    public string Show()
    {
        Console.OutputEncoding = Encoding.Unicode;

        Console.Clear();
        var header = new FigletText("Backlang Manager").Centered();

        var pnl = new Panel(header);
        pnl.BorderStyle(Style.Parse("White"));
        header.Color = ConsoleColor.Blue;

        AnsiConsole.Write(pnl);

        var prompt = new SelectionPrompt<string>();

        if (Parent != null)
        {
            prompt.AddChoice("..");
        }

        foreach (var item in Items)
        {
            prompt.AddChoice(item.Key);
        }

        

        var selectedItem = AnsiConsole.Prompt(prompt);

        if (selectedItem == "..")
        {
            Parent?.Show();
            return string.Empty;
        }

        Items[selectedItem]?.Invoke(this);

        return selectedItem;
    }
}
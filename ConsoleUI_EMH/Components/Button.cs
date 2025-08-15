namespace ConsoleUI_EMH;

public class Button : ControlBase
{
    int defaultWidth = 20;
    public string Content = "";
    Action _onClicked;
    public Button(string content)
    {
        Content = content;
    }
    public Button(string content, Action? onClicked = null)
    {
        Content = content;
        _onClicked = onClicked;
    }

    public override (int Width, int Height) GetSize()
    {
        return (defaultWidth, 1);
    }

    public override void Render()
    {
        Render(defaultWidth, 1);
    }

    public override void Render(int maxWidth, int maxHeight)
    {
        Console.BackgroundColor = IsActive() ? ConsoleColor.DarkYellow : ConsoleColor.DarkBlue;
        Console.ForegroundColor = ConsoleColor.White;

        int width = Math.Min(defaultWidth, maxWidth);
        string content = Content;

        if (content.Length > width)
        {
            content = content.Substring(0, width);
        }
        else if (content.Length < width)
        {
            int padding = (width - content.Length) / 2;
            content = content.PadLeft(content.Length + padding).PadRight(width);
        }

        Console.Write(content);
        Console.ResetColor();
    }

    public override void HandleKeyInfo(ConsoleKeyInfo keyInfo)
    {
        switch (keyInfo.Key)
        {
            case ConsoleKey.Enter:
                if (_onClicked != null)
                {
                    _onClicked?.Invoke();
                }
                break;
        }
    }
}
namespace ConsoleUI_EMH;

public class TextBox : ControlBase
{
    int defaultWidth = 20;
    public string Content = "";
    public TextBox()
    {

    }
    public TextBox(string content)
    {
        Content = content;
    }
    public override void Render()
    {
        Render(defaultWidth, 1);
    }

    public override void Render(int maxWidth, int maxHeight)
    {
        // Prøv tydeligere farver
        Console.BackgroundColor = IsActive() ? ConsoleColor.Yellow : ConsoleColor.Gray;
        Console.ForegroundColor = ConsoleColor.Black;

        string content = Content;
        int width = Math.Min(defaultWidth, maxWidth);

        if (content.Length > width)
        {
            content = content.Substring(0, width);
        }
        else if (content.Length < width)
        {
            content = content.PadRight(width);
        }

        Console.Write(content);
        Console.ResetColor();
    }
    public override (int Width, int Height) GetSize()
    {
        string[] lines = Content.Split("\n");
        int height = lines.Length;
        int width = defaultWidth;
        foreach (string line in lines)
        {
            if (line.Length > width)
            {
                width = line.Length;
            }
        }
        return (width, height);
    }

    public override void HandleKeyInfo(ConsoleKeyInfo keyInfo)
    {
        switch (keyInfo.Key)
        {
            case ConsoleKey.Backspace:
                if (Content.Length > 0)
                    Content = Content.Substring(0, Content.Length - 1);
                break;
            default:
                if (Content.Length < defaultWidth && !char.IsControl(keyInfo.KeyChar))
                    Content += keyInfo.KeyChar;
                break;
        }
    }
}
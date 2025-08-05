namespace ConsoleUI_EMH;

public class NumberBox : ControlBase
{
    int defaultWidth = 20;
    private int _value = 0;

    public int Value
    {
        get => _value;
        set => _value = value;
    }

    public string Content => _value.ToString();

    public NumberBox()
    {

    }

    public NumberBox(int value)
    {
        _value = value;
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
        return (defaultWidth, 1);
    }

    public override void HandleKeyInfo(ConsoleKeyInfo keyInfo)
    {
        switch (keyInfo.Key)
        {
            case ConsoleKey.Backspace:
                if (_value > 0)
                    _value = _value / 10; // Fjern sidste ciffer
                break;
            case ConsoleKey.UpArrow:
                _value++;
                break;
            case ConsoleKey.DownArrow:
                if (_value > 0)
                    _value--;
                break;
            default:
                // Kun tilføj tal
                if (char.IsDigit(keyInfo.KeyChar))
                {
                    _value = _value * 10 + (keyInfo.KeyChar - '0');
                }
                break;
        }
    }
}
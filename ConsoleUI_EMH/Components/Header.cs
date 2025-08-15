namespace ConsoleUI_EMH;

public class Header : UIElement
{
    public string Content = "";
    public Header()
    {

    }
    public Header(string content)
    {
        Content = content;
    }

    public override void Render()
    {
        Render(int.MaxValue, int.MaxValue);
    }

    public override void Render(int maxWidth, int maxHeight)
    {
        string text = Content.ToUpper();
        if (text.Length > maxWidth)
            text = text.Substring(0, maxWidth);
        Console.Write(text);
    }
    public override (int Width, int Height) GetSize()
    {
        string[] lines = Content.Split("\n");
        int height = lines.Length;
        int width = 0;
        foreach (string line in lines)
        {
            if (line.Length > width)
            {
                width = line.Length;
            }
        }
        return (width, height);
    }
}
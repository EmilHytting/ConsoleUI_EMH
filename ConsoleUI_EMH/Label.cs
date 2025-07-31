namespace ConsoleUI_EMH
{
public class Label: UIElement
{
    public string Content = "";
    public Label()
    {

    }
    public Label(string content)
    {
        Content = content;
    }

    public override void Render()
    {
        Console.Write(Content);
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
}
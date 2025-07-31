namespace ConsoleUI_EMH;

public class Button : UIElement
{


    public string Content = "";
    public Button()
    {

    }
    public Button(string content)
    {
        Content = content;
    }

    public override void Render()
    {
        Console.BackgroundColor = ConsoleColor.White;
        Console.ForegroundColor = ConsoleColor.Black;
        Console.Write(Content);
        Console.ResetColor(); // For at den kun farver knappens bagrund - 
                              // og ikke hele console.
    }

    public override (int Width, int Height) GetSize()
    {
        return (Content.Length, 1);

    }
}